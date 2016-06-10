#region Using Directives
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

using PTNK.Entities;
using PTNK.Data;
#endregion

namespace PTNK.Services
{
	/// <summary>
	/// The base class that each component business domain service of the model implements.
	/// </summary>
	[CLSCompliant(true)]
	public abstract partial class ServiceViewBase<Entity> : ServiceViewBaseCore<Entity>
        where Entity : new()
	{

	}
}
