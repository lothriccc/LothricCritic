namespace LothricCritic.Areas.GamePanel.Models
{
	public class GameEditViewModel
	{
        public int CompanyID { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string PictureUrl { get; set; }
		public IFormFile Picture { get; set; }
	}
}
