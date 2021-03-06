﻿

/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file KhoiTest.cs instead.
*/

#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using PTNK.Entities;
using PTNK.Data;
using PTNK.Data.Bases;

#endregion

namespace PTNK.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="Khoi"/> objects (entity, collection and repository).
    /// </summary>
   public partial class KhoiTest
    {
    	// the Khoi instance used to test the repository.
		private Khoi mock;
		
		// the TList<Khoi> instance used to test the repository.
		private TList<Khoi> mockCollection;
		
		private static TransactionManager CreateTransaction()
		{
			TransactionManager transactionManager = null;
			if (DataRepository.Provider.IsTransactionSupported)
			{
				transactionManager = DataRepository.Provider.CreateTransaction();
				transactionManager.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
			}			
			return transactionManager;
		}
		       
        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>        
        static public void Init_Generated()
        {		
        	System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the Khoi Entity with the {0} --", PTNK.Data.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
		static public void CleanUp_Generated()
        {   		
			System.Console.WriteLine("All Tests Completed");
			System.Console.WriteLine();
        }
    
    
		/// <summary>
		/// Inserts a mock Khoi entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.KhoiProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.KhoiProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all Khoi objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.KhoiProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.KhoiProvider.Find():");			
				System.Console.WriteLine(mockCollection);
						
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.KhoiProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all Khoi children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.KhoiProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.KhoiProvider.DeepLoading += new EntityProviderBaseCore<Khoi, KhoiKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.KhoiProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("Khoi instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					DataRepository.KhoiProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock Khoi entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				UpdateMockInstance(tm, mock);
				
				Assert.IsTrue(DataRepository.KhoiProvider.Insert(tm, mock), "Insert failed");
				Assert.IsTrue(DataRepository.KhoiProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.KhoiProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock Khoi entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (Khoi)CreateMockInstance(tm);
				DataRepository.KhoiProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.KhoiProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.KhoiProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Khoi entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Khoi.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock Khoi entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_Khoi.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<Khoi>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Khoi collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_KhoiCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<Khoi> mockCollection = new TList<Khoi>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<Khoi> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a Khoi collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_KhoiCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Khoi>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<Khoi> mockCollection = (TList<Khoi>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<Khoi> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Khoi entity = CreateMockInstance(tm);
				bool result = DataRepository.KhoiProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				Khoi entity = CreateMockInstance(tm);
				bool result = DataRepository.KhoiProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				Khoi t0 = DataRepository.KhoiProvider.GetByMaKhoi(tm, entity.MaKhoi);
			}
		}
		
		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		private void Step_20_TestEntityHelper_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				
				Khoi entity = mock.Copy() as Khoi;
				entity = (Khoi)mock.Clone();
				Assert.IsTrue(entity.Equals(mock), "Clone is not working");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Khoi Entity with mock values.
		///</summary>
		static public Khoi CreateMockInstance_Generated(TransactionManager tm)
		{		
			Khoi mock = new Khoi();
						
			mock.MaKhoi = "1e";
			mock.TenKhoi = "V[PL";
			
		
			// create a temporary collection and add the item to it
			TList<Khoi> tempMockCollection = new TList<Khoi>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Khoi)mock;
		}
		
		
		///<summary>
		///  Update the Typed Khoi Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, Khoi mock)
		{
			mock.MaKhoi = "602";
			mock.TenKhoi = "V[PL2";
			
		}
		#endregion
    }
}
