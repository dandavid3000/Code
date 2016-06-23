>This program shows how to connect to SQL Server 2005, and do some basic queries.

###Table of contents
* [Introduction](#introduction)
* [Requirements](#requirements)
* [Interfaces](#interfaces)
 * [Main interface](#main-interface)
 * [Bill interface](#bill-interface)
 * [Search interface](#search-interface)
* [Guide](#guide)

---

#### Introduction
Given a Bill Database (SQL Server 2005) with `PhieuThu` table structure

![Bill table](../../../images/PhieuThu.png "Bill table")

MaPT is a primary key, and it's automatically increased (IDENTITY)

---

#### Requirements

Write a program which allows to do these tasks:

1. Search bills by using `MaPT` (Bill ID), `NgayThu` (Day of Bills), `SoTien` (Money), `LyDoThu` (Reason), `GhiChu` (Notice)
2. Can update/detele/update bills.
3. The program allows inputs as user information

---

#### Interfaces

##### Main interface
* The program will start with a login window. Fill correct information, and click `Log in` to connect to the `SQL Database` or `Exit` to quit the program.

   ![Login interface](../../../images/bill1.PNG "Login interface")

* Abbreviations
  * `Phiếu thu` = `Bills` : Open Bills form
  * `Tìm kiếm` = `Search` : Open Search form
  * `Thông tin` = `Information` : Open Information form and show information about me.
  * `Quản Lý Phiếu Thu` = `Bill management system`

##### Bill interface
* All data in the DB will be shown. There are some features to `Add`, `Delete`, `Update` records.
  
  ![Bill interface](../../../images/bill3.PNG "Bill interface")

* Abbreviations:
 * `Mã PT` = `Bill ID` : It will be automatically created.
 * `Ngày thu` = `Day` : Fill in for the add button.
 * `Lý do thu` = `Reason` : Reason for creating this bill.
 * `Số tiền thu` = `Amount of money`
 * `Ghi chu1` = `Note`
 * `Thêm` = `Add` button : Add new record to the DB and the grid, with information from `Bill ID`, `Day`, `Reason`, `Money`, and `Note`.
 * `Xoá` = `Delete` button : Delete a selected record from the grid.
 * `Sửa` = `Update` button : Update new information for selected record.
 * `Tìm kiếm` = `Search` button : Switch to `Search` form.

##### Search interface

* Search all information by using keywords from checkboxes. 
* Users can search by `Bill ID`, `Day`, `Amount of Money`, `Reason`, or `Note` by ticking the checkboxes, and fill in information
* Click `Tim kiem` = `Seach` to start searching. The result will be shown in the grid.
* `Xoá bảng` = `Empty Grid` button is used to clear the grid.
* `Phiếu Thu` = `Bill` button is used to switch to `Bill` form

   ![Search interface](../../../images/bill4.PNG "Search interface")

---

#### Guide

* Create a Database with `MaPT`=`Bill ID` is `IDENTITY`

   ![DB creation](../../../images/bm0.png "DB creation")

* Open the application. Fill in the information, and click `Log in` to use the program

   ![Log in](../../../images/bm2.PNG "Log in")
   
* There are 3 options which are `Phieu Thu` = `Bills`, `Tim Kiem` = `Search`, and `Thong Tin` = `Information`

   ![Features](../../../images/bm3.PNG "Features")
   
   * Click `Phieu Thu` = `Bills` to open a new window. There is a list of all records in the DB.
   
      ![Bill interface](../../../images/bm4.PNG "Bill interface")
   
      * Insert: Type information and click `Them` to add a new record to the DB
         
         ![Add a new record](../../../images/bm5.PNG "Add a new record")
      
      * Delete: Choose any record from the grid, and click `Xoa` to delete it from the DB
      
         ![Delete a new record](../../../images/bm6.PNG "Delete a new record")

         ![After being deleted](../../../images/bm7.PNG "After being deleted")
         
      * Update: Choose any record from the grid. Modify the inforamtion, and click `Sua` to update it.
      
         ![Modify a new record](../../../images/bm9.PNG "Modify a new record")

         ![After being updated](../../../images/bm10.PNG "After being updated")

   * Click `Tim Kiem` = `Seach` to open Search feature.
      * Choose inputs by ticking boxses.
      * Fill the information, and click `Tim Kiem` to get the result
         
         ![Search feature](../../../images/bm10.PNG "Search feature")

      * `Xoa Bang` is used to clear the grid (Not in the DB).
      
   * Click `Thoat` to exit the program, or close windows.
