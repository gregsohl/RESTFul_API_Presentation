
namespace UserGroupApi_VS2013.Models
{
	public class UserGroupListItem
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Link { get; set; }

		public UserGroupListItem()
		{
		}

		public UserGroupListItem(int id, string name, string link)
		{
			ID = id;
			Name = name;
			Link = link;
		}
	}
}