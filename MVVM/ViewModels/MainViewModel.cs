using Microsoft.Win32;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Shattered_pixel_dungeon_CUSTOM.MVVM.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shattered_pixel_dungeon_CUSTOM.MVVM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {   
        private Hero _hero;
        private Classes _classes;
        private string _filePath;

        public Hero Hero
        {
            get { return _hero ;}
            set { _hero = value; OnPropertyChanged(); }
        }
        public Classes Classes
        {
            get { return _classes; }
            set { _classes = value; }
        }

        public ICommand LoadCommand { get; }
        public ICommand SaveCommand { get; }
        public MainViewModel()
        {
            LoadCommand = new RelayCommand(Load);
            SaveCommand = new RelayCommand(Save);
            Classes = new Classes();
        }
        private void Load(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _filePath = openFileDialog.FileName;
                string json = File.ReadAllText(_filePath);
                var gameData = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

                if (gameData != null && gameData.ContainsKey("hero"))
                {
                    Hero = JsonConvert.DeserializeObject<Hero>(gameData["hero"].ToString());
                }
            }
        }
        private void Save(object parameter)
        {
            if(!string.IsNullOrEmpty(_filePath) && Hero != null)
            {
                string json = File.ReadAllText(_filePath);
                JObject gameData = JObject.Parse(json);
                var heroData = gameData["hero"];
                if (gameData != null && gameData.ContainsKey("hero"))
                {
                    heroData["HP"] = Hero.HealthPoints;
                    heroData["HT"] = Hero.MaxHealthPoints;
                    heroData["STR"] = Hero.Strength;
                    heroData["attackSkill"] = Hero.AttackSkill;
                    string updatedJson = JsonConvert.SerializeObject(gameData, Formatting.Indented);
                    // Змінюємо назву файлу
                    string directory = Path.GetDirectoryName(_filePath);
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(_filePath);
                    string newFileName = fileNameWithoutExtension + ".dat";
                    string newFilePath = Path.Combine(directory, newFileName);
                    // Зберігаємо оновлений JSON у новий файл
                    File.WriteAllText(newFilePath, updatedJson);
                }
            }
        }
    }
}
