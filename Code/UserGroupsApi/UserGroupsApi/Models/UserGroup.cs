using System;

using UserGroupsApi.Utility;

namespace UserGroupsApi.Models
{
	public class UserGroup
	{
		public int Id { get;  set; }
		public string Name { get;  set; }
		public DateTime Formed { get; set; }
		public int CityID { get;  set; }
		public string Website { get;  set; }
		public DateTime LastModified { get; set; }

		public UserGroup()
		{
		}

		public UserGroup(int id, string name, DateTime formed, int cityID, string website)
		{
			Id = id;
			Name = name;
			Formed = formed;
			CityID = cityID;
			Website = website;
			LastModified = DateTime.UtcNow;
		}

		public string GetVersion()
		{
			string keyValue = Id.ToString() + LastModified.Ticks.ToString();
			string hash = Hashes.CalculateMd5Hash(keyValue);

			return hash;
		}
	}
}