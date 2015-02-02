using System;

using UserGroupApi_VS2013.Utility;

namespace UserGroupApi_VS2013.Models
{
	public class UserGroup
	{
		public int Id { get;  set; }
		public string Name { get;  set; }
		public DateTime Formed { get; set; }
		public string Zip { get;  set; }
		public string Website { get;  set; }
		public DateTime LastModified { get; set; }

		public UserGroup()
		{
		}

		public UserGroup(int id, string name, DateTime formed, string zip, string website)
		{
			Id = id;
			Name = name;
			Formed = formed;
			Zip = zip;
			Website = website;

			LastModified = DateTime.UtcNow;
		}

		public string GetVersion()
		{
			string keyValue = Id.ToString() + LastModified.Ticks.ToString();
			string hash = Hashes.CalculateMd5Hash(keyValue);

			return hash;
		}

		public void Update(UserGroup userGroup)
		{
			Name = userGroup.Name;
			Formed = userGroup.Formed;
			Zip = userGroup.Zip;
			Website = userGroup.Website;

			LastModified = DateTime.UtcNow;
		}
	}
}