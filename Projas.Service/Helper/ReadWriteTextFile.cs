using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Projas.Service.Entity;
using Projas.Service.IService;
using Projas.Service.Service;

namespace Projas.Service.Helper
{
    public class APIHelper
    {
      static  string CurrentProjectName = "Projas-Service";
        private static IEnumerable<DateTime> EachDay(DateTime from, DateTime to)
        {
            for (var day = from.Date; day.Date <= to.Date; day = day.AddDays(1))
                yield return day;
        }

        public static   void GetApiData()
        {
            using (var client = new HttpClient())
            {
                var response =  client.GetAsync("https://api.banghasan.com/sholat/format/json/kota").Result;
                response.EnsureSuccessStatusCode();
                var stringData =  response.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrEmpty(stringData)) return;
               
                Log.WriteLog(CurrentProjectName, "Start ImportKotaToFile");
                var tables = JsonConvert.DeserializeObject<Cities>(stringData);
                ReadWriteTextFile.ImportKotaToFile(tables.Kota);
                Log.WriteLog(CurrentProjectName, "End ImportKotaToFile");

                DateTime EndDate = new DateTime(2045, 12, 31);

                foreach (var itm in tables.Kota)
                {
                    Log.WriteLog(CurrentProjectName, $"Start Import All Jadwal Kota {itm.nama} To File");
                    foreach (DateTime day in EachDay(DateTime.Today, EndDate))
                    {
                        var url = $"https://api.banghasan.com/sholat/format/json/jadwal/kota/{itm.id}/tanggal/{day.ToString("yyyy-MM-dd")}";
                        var responseJadwal =  client.GetAsync(url).Result;
                        responseJadwal.EnsureSuccessStatusCode();
                        var stringDataJadwal =  responseJadwal.Content.ReadAsStringAsync().Result;
                        if (string.IsNullOrEmpty(stringDataJadwal)) return;

                        var tablesJadwal = JsonConvert.DeserializeObject<Schedules>(stringDataJadwal);
                        var jadwalKota = tablesJadwal.jadwal.data;
                        jadwalKota.kota = itm.nama;
                        try
                        {
                            ReadWriteTextFile.ImportJadwalKotaToFile(jadwalKota);
                        }
                        catch (Exception e)
                        {
                            Log.WriteLog(CurrentProjectName, $"Error ImportJadwalKotaToFile, Kota : {itm.nama}, Tanggal : {day.ToString("yyyy-MM-dd")}. Error Message  : {e.Message} ");
                        }
                       

                    }
                    Log.WriteLog(CurrentProjectName, $"End Import All Jadwal Kota {itm.nama} To File");
                }





            }

        }
    }

   public class ReadWriteTextFile
    {
        static string CurrentProjectName = "Projas-Service";
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();

        public static void ImportKotaToFile(List<City> lst)
        {
            string strFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TextData";

            if (!Directory.Exists(strFolder)) Directory.CreateDirectory(strFolder);
            String strFileName = "DaftarKota.txt";
            strFileName = strFolder + @"\" + strFileName;
        
            _readWriteLock.EnterWriteLock();

            try
            {
                // Append text to the file
                using (StreamWriter sw = File.AppendText(strFileName))
                {
                    // sw.WriteLine(msg);
                    foreach (var itm in lst)
                    {
                        sw.WriteLine(itm.nama);
                    }
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }

        public static void ImportJadwalKotaToFile(Jadwal obj)
        {
            string LogFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TextData";

            if (!Directory.Exists(LogFolder)) Directory.CreateDirectory(LogFolder);
            String LogFileName = $"Jadwal-{obj.kota}.txt";
            LogFileName = LogFolder + @"\" + LogFileName;

            _readWriteLock.EnterWriteLock();

            try
            {
                // Append text to the file
                using (StreamWriter sw = File.AppendText(LogFileName))
                {
                     sw.WriteLine($"{obj.kota};{obj.ashar};{obj.dhuha};{obj.dzuhur};{obj.imsak};{obj.isya};{obj.maghrib};{obj.subuh};{obj.tanggal};{obj.terbit}");

                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }

        public static void ExportKotaToDB(string fileName)
        {
            Log.WriteLog(CurrentProjectName, "Start ExportKotaToDB");
            string strFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TextData";
            var strFileName = strFolder + @"\" + fileName;
            var source = File.ReadLines(strFileName).Select(line => line.Split(';'));
            var lst= new List<City>();
            foreach (var itm in source)
            {
                var obj=new City();
                obj.nama = itm[0];
                lst.Add(obj);
            }

            try
            {
                using (IDapperContext dapperContext = new DapperContext())
                {
                    IUnitOfWork uow = new UnitOfWork(dapperContext);
                    uow.BeginTransaction();
                    uow.cityService.InsertAll(lst);
                    uow.Commit();
                }
            }
            catch (Exception e)
            {
                Log.WriteLog(CurrentProjectName, $"Error ExportKotaToDB: {e.Message}");
            }
            finally
            {
                Log.WriteLog(CurrentProjectName, "End ExportKotaToDB");
            }
           
        }

        public static void ExportJadwalKotaToDB()
        {
            string strFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\TextData";

            string[] filePaths = Directory.GetFiles(strFolder);
            foreach (var path in filePaths)
            {
                if (Path.GetFileName(path) == "DaftarKota.txt") continue;
                var source = File.ReadLines(path).Select(line => line.Split(';'));
                var intCount = source.Count();

                var intSkip = 0;
                var intBatch = 50;
                var isLoop = true;
                
                string query = "";
                var bloop = true;
                do
                {
                    var lst = new List<Jadwal>();
                    if (intSkip == 0)
                    {
                        source = File.ReadLines(path).Select(line => line.Split(';')).Take(intBatch);
                    }
                    else
                    {
                        source = File.ReadLines(path).Select(line => line.Split(';')).Skip(intSkip).Take(intBatch);
                    }

                    foreach (var itm in source)
                    {
                        var obj = new Jadwal();
                        obj.kota = itm[0];
                        obj.ashar = itm[1];
                        obj.dhuha = itm[2];
                        obj.dzuhur = itm[3];
                        obj.imsak = itm[4];
                        obj.isya = itm[5];
                        obj.maghrib = itm[6];
                        obj.subuh = itm[7];
                        obj.tanggal = itm[8];
                        obj.terbit = itm[9];
                        lst.Add(obj);
                    }

                    try
                    {
                        using (IDapperContext dapperContext = new DapperContext())
                        {
                            IUnitOfWork uow = new UnitOfWork(dapperContext);
                            uow.BeginTransaction();
                            uow.jadwalService.InsertAll(lst);
                            uow.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        Log.WriteLog(CurrentProjectName, $"Error ExportJadwalKotaToDB: {e.Message}");
                    }
                   
                    intSkip += intBatch;
                    if (intSkip > intCount)
                    {
                        bloop = false;
                    }

                } while (bloop);
            }

        }

    }
}
