using Newtonsoft.Json;
using System.Collections.Generic;
using Prism.Mvvm;

namespace ContosoCookbook.Business
{
    public class Recipe : BindableBase
    {
        private string _imagePath;
        private string _subtitle;
        private List<string> _ingredients;
        private string _directions;
        private int _prepTime;
        private string _description;
        private string _title;

        [JsonProperty("UniqueId")]
        public string ID { get; set; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Subtitle
        {
            get => _subtitle;
            set => SetProperty(ref _subtitle, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }

        public string TileImagePath { get; set; }

        public int PrepTime
        {
            get => _prepTime;
            set => SetProperty(ref _prepTime, value);
        }

        public string Directions
        {
            get => _directions;
            set => SetProperty(ref _directions, value);
        }

        public List<string> Ingredients
        {
            get => _ingredients;
            set => SetProperty(ref _ingredients, value);
        }
    }
}
