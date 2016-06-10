﻿#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using PTNK.Entities;
using PTNK.Data;

#endregion

namespace PTNK.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="RangBuocLopHocProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RangBuocLopHocProviderBase : RangBuocLopHocProviderBaseCore
	{
	} // end class
} // end namespace
