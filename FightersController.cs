using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace sharpy
{
    public class FightersController
    {
        public string pathCsvFile = "D:\\file.csv";


        public void CreateFile()
        {
            using (FileStream fileStream = File.Create(pathCsvFile))
            {
                string s1 = "FirstName,Surname,Rating,Weight";
                byte[] array = System.Text.Encoding.Default.GetBytes(s1);
                string s2 = "0,0,0,0";
                byte[] array2 = System.Text.Encoding.Default.GetBytes(s2);
                byte[] array3 = System.Text.Encoding.Default.GetBytes("\n");
                fileStream.Write(array, 0, array.Length);
                fileStream.Write(array3, 0, array3.Length);
                fileStream.Write(array2, 0, array2.Length);
                fileStream.Write(array3, 0, array3.Length);
            }
            //using (FileStream fstream = System.IO.File.Create(pathCsvFile))

        }

        public List<Fighter> Search(Fighter fighter)
        {
            if (fighter == null)
            {
                throw new ArgumentException("The fighter doesn't exists");
            }
            var result = new List<Fighter>();
            var fighters = GetAllFighters();
            
            foreach (var man in fighters)
            {
                if (man.FirstName == fighter.FirstName && man.Surname == fighter.Surname &&
                    man.Rating == fighter.Rating && man.Weight == fighter.Weight)
                {
                    result.Add(man);
                    break;
                }
                else
                {
                    MessageBox.Show(" Error: Fighter not found! ");
                    break;
                }
            }

            return result;
        }

        public List<Fighter> Edit(Fighter fighter)
        {
            if (fighter == null)
            {
                throw new ArgumentException("The fighter doesn't exists");
            }
            var editfighter = new List<Fighter>();
            return editfighter;
        }

        public void AddNewFighter(Fighter fighter)
        {
            if (fighter == null)
            {
                throw new ArgumentException("The fighter doesn't exists");
            }
            List<Fighter> mans = GetAllFighters();
            List<Fighter>fighters = new List<Fighter>();
            foreach (var man in mans)
            {
                foreach (char c in fighter.FirstName)
                {
                        if (Char.IsNumber(c))
                        {
                            MessageBox.Show("Error:invalid symbols");
                            throw new Exception("Error:invalid symbols");
                        }
                }
                foreach (char b in fighter.Surname)
                    if  (Char.IsNumber(b))
                    {
                        MessageBox.Show("Error:invalid symbols");
                        throw new Exception("Error:invalid symbols");
                    }

                if (fighter.Surname == man.Surname)
                {
                    MessageBox.Show("Error:Fighter with this name has already been registered! ");
                    throw new Exception("Error:Fighter with this name has already been registered!");
                }
            }
            fighters.Add(fighter); 
            
            
            CsvConfiguration config = new CsvConfiguration
            {
                HasHeaderRecord = false,
                Delimiter = ","
            };


            using (var stream = File.Open(pathCsvFile, FileMode.Append))
            using (var streamWriter = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(streamWriter, config))
            {
                csvWriter.WriteRecords(fighters);
            }

        }

        public List<string> GetNamesList()
        {
            List<Fighter> fighters = GetAllFighters();
            var result = new List<string>();
            foreach (var fighter in fighters)
            {
                result.Add(fighter.FirstName);
            }

            return result;
        }

        public Fighter GetFighterByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentException("The fighter doesn't exists");
            }
            Fighter result = new Fighter();

            var fighters = GetAllFighters();
            foreach (var fighter in fighters)
            {
                if (fighter.FirstName == name)
                    result = fighter;
            }

            return result;
        }

        public void DeleteFighter(Fighter fighter)
        {
            if (fighter == null)
            {
                throw new ArgumentException("The fighter doesn't exists");
            }
            var newFighters = GetAllFighters();
            CsvConfiguration config = new CsvConfiguration
            {
                HasHeaderRecord = false,
                Delimiter = ","
            };
            var deletedFighter = newFighters.Where(o => o.FirstName == fighter.FirstName).SingleOrDefault();
            var a = newFighters.Remove(deletedFighter);
            CreateFile();
            using (var stream = File.Open(pathCsvFile, FileMode.Append))
            using (var streamWriter = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(streamWriter, config))
            {
                csvWriter.WriteRecords(newFighters);
            }
        }
        
        public void EditFighter(Fighter oldFighter, Fighter newFighter)
        {
            if (oldFighter == null)
            {
                throw new ArgumentException("The fighter doesn't exists");
            }
            
            DeleteFighter(oldFighter);
            AddNewFighter(newFighter);
        }

        public List<Fighter> GetAllFighters()
            {
                var result = new List<Fighter>();
                int count = result.Count;
                decimal[] a = new Decimal[count];
                
                using (TextReader textReader = File.OpenText(pathCsvFile))
                using (CsvReader csvReader = new CsvReader(textReader))
                {
                    csvReader.Read();
                    var fighters = csvReader.GetRecords<Fighter>();

                    foreach (var fighter in fighters)
                    {

                        {
                            result.Add(fighter);
                        }
                    }
                }

                //создаем файловый поток
                return result;
            }
        }
    }