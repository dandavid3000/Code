﻿

/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file BangThamSoTest.cs instead.
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
    /// Provides tests for the and <see cref="BangThamSo"/> objects (entity, collection and repository).
    /// </summary>
   public partial class BangThamSoTest
    {
    	// the BangThamSo instance used to test the repository.
		private BangThamSo mock;
		
		// the TList<BangThamSo> instance used to test the repository.
		private TList<BangThamSo> mockCollection;
		
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
			System.Console.WriteLine("-- Testing the BangThamSo Entity with the {0} --", QuanLyHocSinhPTNK.Data.DataRepository.Provider.Name);
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
		/// Inserts a mock BangThamSo entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.BangThamSoProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.BangThamSoProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all BangThamSo objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.BangThamSoProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.BangThamSoProvider.Find():");			
				System.Console.WriteLine(mockCollection);
						
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.BangThamSoProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all BangThamSo children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.BangThamSoProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.BangThamSoProvider.DeepLoading += new EntityProviderBaseCore<BangThamSo, BangThamSoKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.BangThamSoProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("BangThamSo instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					DataRepository.BangThamSoProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock BangThamSo entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				UpdateMockInstance(tm, mock);
				
				Assert.IsTrue(DataRepository.BangThamSoProvider.Insert(tm, mock), "Insert failed");
				Assert.IsTrue(DataRepository.BangThamSoProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.BangThamSoProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock BangThamSo entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (BangThamSo)CreateMockInstance(tm);
				DataRepository.BangThamSoProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.BangThamSoProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.BangThamSoProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock BangThamSo entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_BangThamSo.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock BangThamSo entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_BangThamSo.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<BangThamSo>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a BangThamSo collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_BangThamSoCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<BangThamSo> mockCollection = new TList<BangThamSo>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<BangThamSo> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a BangThamSo collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_BangThamSoCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<BangThamSo>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<BangThamSo> mockCollection = (TList<BangThamSo>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<BangThamSo> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				BangThamSo entity = CreateMockInstance(tm);
				bool result = DataRepository.BangThamSoProvider.Insert(tm, entity);
				
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
				BangThamSo entity = CreateMockInstance(tm);
				bool result = DataRepository.BangThamSoProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				BangThamSo t0 = DataRepository.BangThamSoProvider.GetByMaBangThamSo(tm, entity.MaBangThamSo);
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
				
				BangThamSo entity = mock.Copy() as BangThamSo;
				entity = (BangThamSo)mock.Clone();
				Assert.IsTrue(entity.Equals(mock), "Clone is not working");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed BangThamSo Entity with mock values.
		///</summary>
		static public BangThamSo CreateMockInstance_Generated(TransactionManager tm)
		{		
			BangThamSo mock = new BangThamSo();
						
			mock.MaBangThamSo = "V[PLee";
			mock.SoTuoiToiThieu = (int)149;
			mock.SoTuoiToiDa = (int)149;
			mock.SiSoToiDa = (int)149;
			mock.SoMonHoc = (int)149;
			mock.DiemChuan = 149.0f;
			mock.SoQuanLyToiDa = (int)149;
			mock.SoTietHocLienTiep = (int)149;
			
		
			// create a temporary collection and add the item to it
			TList<BangThamSo> tempMockCollection = new TList<BangThamSo>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (BangThamSo)mock;
		}
		
		
		///<summary>
		///  Update the Typed BangThamSo Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, BangThamSo mock)
		{
			mock.MaBangThamSo = "V[PL692";
			mock.SoTuoiToiThieu = (int)149;
			mock.SoTuoiToiDa = (int)149;
			mock.SiSoToiDa = (int)149;
			mock.SoMonHoc = (int)149;
			mock.DiemChuan = 149.0f;
			mock.SoQuanLyToiDa = (int)149;
			mock.SoTietHocLienTiep = (int)149;
			
		}
		#endregion
    }
}
