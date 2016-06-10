﻿

/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file RangBuocGiaoVienTest.cs instead.
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
    /// Provides tests for the and <see cref="RangBuocGiaoVien"/> objects (entity, collection and repository).
    /// </summary>
   public partial class RangBuocGiaoVienTest
    {
    	// the RangBuocGiaoVien instance used to test the repository.
		private RangBuocGiaoVien mock;
		
		// the TList<RangBuocGiaoVien> instance used to test the repository.
		private TList<RangBuocGiaoVien> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the RangBuocGiaoVien Entity with the {0} --", PTNK.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock RangBuocGiaoVien entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.RangBuocGiaoVienProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.RangBuocGiaoVienProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all RangBuocGiaoVien objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.RangBuocGiaoVienProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.RangBuocGiaoVienProvider.Find():");			
				System.Console.WriteLine(mockCollection);
						
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.RangBuocGiaoVienProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all RangBuocGiaoVien children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.RangBuocGiaoVienProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.RangBuocGiaoVienProvider.DeepLoading += new EntityProviderBaseCore<RangBuocGiaoVien, RangBuocGiaoVienKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.RangBuocGiaoVienProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("RangBuocGiaoVien instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					DataRepository.RangBuocGiaoVienProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock RangBuocGiaoVien entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				UpdateMockInstance(tm, mock);
				
				Assert.IsTrue(DataRepository.RangBuocGiaoVienProvider.Insert(tm, mock), "Insert failed");
				Assert.IsTrue(DataRepository.RangBuocGiaoVienProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.RangBuocGiaoVienProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock RangBuocGiaoVien entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (RangBuocGiaoVien)CreateMockInstance(tm);
				DataRepository.RangBuocGiaoVienProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.RangBuocGiaoVienProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.RangBuocGiaoVienProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock RangBuocGiaoVien entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_RangBuocGiaoVien.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock RangBuocGiaoVien entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_RangBuocGiaoVien.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<RangBuocGiaoVien>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a RangBuocGiaoVien collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_RangBuocGiaoVienCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<RangBuocGiaoVien> mockCollection = new TList<RangBuocGiaoVien>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<RangBuocGiaoVien> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a RangBuocGiaoVien collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_RangBuocGiaoVienCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<RangBuocGiaoVien>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<RangBuocGiaoVien> mockCollection = (TList<RangBuocGiaoVien>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<RangBuocGiaoVien> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				RangBuocGiaoVien entity = CreateMockInstance(tm);
				bool result = DataRepository.RangBuocGiaoVienProvider.Insert(tm, entity);
				
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
				RangBuocGiaoVien entity = CreateMockInstance(tm);
				bool result = DataRepository.RangBuocGiaoVienProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				RangBuocGiaoVien t0 = DataRepository.RangBuocGiaoVienProvider.GetByMaRangBuocGiaoVien(tm, entity.MaRangBuocGiaoVien);
				TList<RangBuocGiaoVien> t1 = DataRepository.RangBuocGiaoVienProvider.GetByMaGiaoVien(tm, entity.MaGiaoVien);
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
				
				RangBuocGiaoVien entity = mock.Copy() as RangBuocGiaoVien;
				entity = (RangBuocGiaoVien)mock.Clone();
				Assert.IsTrue(entity.Equals(mock), "Clone is not working");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed RangBuocGiaoVien Entity with mock values.
		///</summary>
		static public RangBuocGiaoVien CreateMockInstance_Generated(TransactionManager tm)
		{		
			RangBuocGiaoVien mock = new RangBuocGiaoVien();
						
			mock.MaRangBuocGiaoVien = "ISWc7";
			mock.Thu = (byte)97;
			mock.TietHoc = (byte)97;
			mock.TrangThai = (byte)97;
			
			//OneToOneRelationship
			GiaoVien mockGiaoVienByMaGiaoVien = GiaoVienTest.CreateMockInstance(tm);
			DataRepository.GiaoVienProvider.Insert(tm, mockGiaoVienByMaGiaoVien);
			mock.MaGiaoVien = mockGiaoVienByMaGiaoVien.MaGiaoVien;
					
		
			// create a temporary collection and add the item to it
			TList<RangBuocGiaoVien> tempMockCollection = new TList<RangBuocGiaoVien>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (RangBuocGiaoVien)mock;
		}
		
		
		///<summary>
		///  Update the Typed RangBuocGiaoVien Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, RangBuocGiaoVien mock)
		{
			mock.MaRangBuocGiaoVien = "ISW332";
			mock.Thu = (byte)97;
			mock.TietHoc = (byte)97;
			mock.TrangThai = (byte)97;
			
			//OneToOneRelationship
			GiaoVien mockGiaoVienByMaGiaoVien = GiaoVienTest.CreateMockInstance(tm);
			DataRepository.GiaoVienProvider.Insert(tm, mockGiaoVienByMaGiaoVien);
			mock.MaGiaoVien = mockGiaoVienByMaGiaoVien.MaGiaoVien;
		}
		#endregion
    }
}