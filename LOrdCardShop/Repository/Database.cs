using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace LOrdCardShop.Repository
{
	public class Database
	{
		private LOrdCardShopVBLEntities db = null;

		public LOrdCardShopVBLEntities GetInstance()
		{
			if (db == null)
			{
                db = new LOrdCardShopVBLEntities();
            }
			return db;
		}
	}
}