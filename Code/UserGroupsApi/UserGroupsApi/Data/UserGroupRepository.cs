using System;
using System.Collections.Generic;
using UserGroupsApi.Models;

namespace UserGroupsApi.Data
{
	public class UserGroupRepository : Dictionary<int, UserGroup>
	{
		public static UserGroupRepository Respository = new UserGroupRepository();

		static UserGroupRepository()
		{
			Respository.Add(1, new UserGroup(1, "CRineta", new DateTime(2002, 01, 01), "52401", "crineta.org"));
			Respository.Add(2, new UserGroup(2, "Iowa .NET User Group", new DateTime(2001, 01, 01), "50309", "iadnug.org"));
			Respository.Add(3, new UserGroup(3, "Lincoln .NET User Group", new DateTime(2004, 01, 01), "68502", "www.lincolndev.net"));
		}
	}
}