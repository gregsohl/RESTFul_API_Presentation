namespace UserGroupsApi.Models
{
	public class City
	{
		public int ID { get; private set; }
		public string CityName { get; private set; }
		public string State { get; private set; }
		public float Latitude { get; private set; }
		public float Longitude { get; private set; }
		public string Zip { get; private set; }

		public City(int id, string cityName, string state, float latitude, float longitude, string zip)
		{
			ID = id;
			CityName = cityName;
			State = state;
			Latitude = latitude;
			Longitude = longitude;
			Zip = zip;
		}
	}
}