﻿

/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file BangDiemTest.cs instead.
*/

#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using QuanLyHocSinhPTNK.Entities;
using QuanLyHocSinhPTNK.Data;
using QuanLyHocSinhPTNK.Data.Bases;

#endregion

namespace QuanLyHocSinhPTNK.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="BangDiem"/> objects (entity, collection and repository).
    /// </summary>
   public partial class BangDiemTest
    {
    	// the BangDiem instance used to test the repository.
		private BangDiem mock;
		
		// the TList<BangDiem> instance used to test the repository.
		private TList<BangDiem> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the BangDiem Entity with the {0} --", QuanLyHocSinhPTNK.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock BangDiem entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.BangDiemProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.BangDiemProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all BangDiem objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.BangDiemProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.BangDiemProvider.Find():");			
				System.Console.WriteLine(mockCollection);
						
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.BangDiemProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all BangDiem children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.BangDiemProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.BangDiemProvider.DeepLoading += new EntityProviderBaseCore<BangDiem, BangDiemKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.BangDiemProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("BangDiem instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					DataRepository.BangDiemProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock BangDiem entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				UpdateMockInstance(tm, mock);
				
				Assert.IsTrue(DataRepository.BangDiemProvider.Insert(tm, mock), "Insert failed");
				Assert.IsTrue(DataRepository.BangDiemProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.BangDiemProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock BangDiem entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (BangDiem)CreateMockInstance(tm);
				DataRepository.BangDiemProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.BangDiemProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.BangDiemProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock BangDiem entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_BangDiem.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock BangDiem entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_BangDiem.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<BangDiem>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a BangDiem collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_BangDiemCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<BangDiem> mockCollection = new TList<BangDiem>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<BangDiem> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a BangDiem collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_BangDiemCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<BangDiem>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<BangDiem> mockCollection = (TList<BangDiem>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<BangDiem> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				BangDiem entity = CreateMockInstance(tm);
				bool result = DataRepository.BangDiemProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
				TList<BangDiem> t0 = DataRepository.BangDiemProvider.GetByMaHocSinh(tm, entity.MaHocSinh, 0, 10);
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				BangDiem entity = CreateMockInstance(tm);
				bool result = DataRepository.BangDiemProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				BangDiem t0 = DataRepository.BangDiemProvider.GetByMaBangDiem(tm, entity.MaBangDiem);
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
				
				BangDiem entity = mock.Copy() as BangDiem;
				entity = (BangDiem)mock.Clone();
				Assert.IsTrue(entity.Equals(mock), "Clone is not working");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed BangDiem Entity with mock values.
		///</summary>
		static public BangDiem CreateMockInstance_Generated(TransactionManager tm)
		{		
			BangDiem mock = new BangDiem();
						
			mock.MaBangDiem = "V[PL93";
			mock.Dtb = 171.0f;
			
			int count0 = 0;
			TList<HocSinh> _collection0 = DataRepository.HocSinhProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.MaHocSinh = _collection0[0].MaHocSinh;
			}
		
			// create a temporary collection and add the item to it
			TList<BangDiem> tempMockCollection = new TList<BangDiem>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (BangDiem)mock;
		}
		
		
		///<summary>
		///  Update the Typed BangDiem Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, BangDiem mock)
		{
			mock.MaBangDiem = "V[PL432";
			mock.Dtb = 131.0f;
			
			int count0 = 0;
			TList<HocSinh> _collection0 = DataRepository.HocSinhProvider.GetPaged(tm, 0, 10, out count0);
			//_collection0.Shuffle();
			if (_collection0.Count > 0)
			{
				mock.MaHocSinh = _collection0[0].MaHocSinh;
			}
		}
		#endregion
    }
}
