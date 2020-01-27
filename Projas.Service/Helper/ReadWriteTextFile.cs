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
        private static IEnumerable<DateTime> EachDay(DateTime from, DateTime to)
        {
            for (var day = from.Date; day.Date <= to.Date; day = day.AddDays(1))
                yield return day;
        }

        public static  async void GetApiData()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://api.banghasan.com/sholat/format/json/kota");
                response.EnsureSuccessStatusCode();
                var stringData = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(stringData)) return;

                var tables = JsonConvert.DeserializeObject<Cities>(stringData);
                ReadWriteTextFile.ImportKotaToFile(tables.Kota);


                DateTime EndDate = new DateTime(2045, 12, 31);

                foreach (var itm in tables.Kota)
                {
                    foreach (DateTime day in EachDay(DateTime.Today, EndDate))
                    {
                        var url = $"https://api.banghasan.com/sholat/format/json/jadwal/kota/{itm.id}/tanggal/{day.ToString("yyyy-MM-dd")}";
                        var responseJadwal = await client.GetAsync(url);
                        responseJadwal.EnsureSuccessStatusCode();
                        var stringDataJadwal = await responseJadwal.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(stringDataJadwal)) return;

                        var tablesJadwal = JsonConvert.DeserializeObject<Schedules>(stringDataJadwal);
                        var jadwalKota = tablesJadwal.jadwal.data;
                        jadwalKota.kota = itm.nama;
                        ReadWriteTextFile.ImportJadwalKotaToFile(jadwalKota);

                    }
                }





            }

        }
    }

   public class ReadWriteTextFile
    {
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
            using (IDapperContext dapperContext = new DapperContext())
            {
                IUnitOfWork uow = new UnitOfWork(dapperContext);
                uow.BeginTransaction();
                uow.cityService.InsertAll(lst);
                uow.Commit();
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
                    using (IDapperContext dapperContext = new DapperContext())
                    {
                        IUnitOfWork uow = new UnitOfWork(dapperContext);
                        uow.BeginTransaction();
                        uow.jadwalService.InsertAll(lst);
                        uow.Commit();
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
