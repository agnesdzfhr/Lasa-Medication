﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Models
{
	public class User
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Fullname { get; set; }
		public string Email { get; set; }
	}
}
