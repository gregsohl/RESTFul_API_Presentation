﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Routing;

using UserGroupsApi.Models;

namespace UserGroupsApi.Controllers
{
	public class UserGroupsController : ApiController
	{
		// GET api/values
		public IEnumerable<UserGroupListItem> Get()
		{
			var results = new List<UserGroupListItem>();
			foreach (var userGroup in Data.UserGroupRepository.Respository.Values)
			{
				var urlHelper = new UrlHelper(Request);
				var link = urlHelper.Link("DefaultApi", new {controller = "UserGroup", id = userGroup.Id});
				var resultItem = new UserGroupListItem(userGroup.Id, userGroup.Name, link);
				results.Add(resultItem);
			}

			return results;
		}

		// GET api/usergroups/5
		public HttpResponseMessage Get(int id)
		{
			UserGroup userGroup;
			bool found = Data.UserGroupRepository.Respository.TryGetValue(id, out userGroup);
			if (found)
			{
				var response = Request.CreateResponse(HttpStatusCode.OK, userGroup);
				response.Headers.ETag = new EntityTagHeaderValue("\"" + userGroup.GetVersion() + "\"");
				response.Headers.CacheControl = new CacheControlHeaderValue();
				response.Headers.CacheControl.MaxAge = new TimeSpan(1, 0, 0);

				return response;
			}

			return Request.CreateErrorResponse(HttpStatusCode.NotFound,"The user group specified was not found.");
		}

		// POST api/usergroups
		public HttpResponseMessage Post([FromBody]UserGroup userGroup)
		{
			UserGroup existingUserGroup;
			bool found = Data.UserGroupRepository.Respository.TryGetValue(userGroup.Id, out existingUserGroup);
			if (found)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Duplicate UserGroup ID specified.");
			}

			Data.UserGroupRepository.Respository.Add(userGroup.Id, userGroup);

			var response = Request.CreateResponse(HttpStatusCode.OK, userGroup);
			response.Headers.ETag = new EntityTagHeaderValue("\"" + userGroup.GetVersion() + "\"");
			response.Headers.CacheControl = new CacheControlHeaderValue();
			response.Headers.CacheControl.MaxAge = new TimeSpan(1, 0, 0);

			return response;
		}

		// PUT api/usergroups/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/usergroups/5
		public void Delete(int id)
		{
		}
	}
}