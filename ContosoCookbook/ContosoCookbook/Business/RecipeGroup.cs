using Newtonsoft.Json;
using System.Collections.Generic;
using Prism.Mvvm;

namespace ContosoCookbook.Business
{
    public class RecipeGroup: BindableBase
    {
        private List<Recipe> _recipes;
        private string _title;
        private string _subtitle;
        private string _imagePath;

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

        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }

        public string GroupImagePath { get; set; }
        public string Description { get; set; }

        [JsonProperty("Items")]
        public List<Recipe> Recipes
        {
            get => _recipes;
            set => SetProperty(ref _recipes, value);
        }
    }
}
