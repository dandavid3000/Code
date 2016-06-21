>This program shows how to connect to SQL Server 2005, and do some basic queries.

#### Introduction
Given a Bill Database (SQL Server 2005) with `PhieuThu` table structure

![Bill table](../../../images/PhieuThu.png "Bill table")

MaPT is a primary key, and it's automatically increased (IDENTITY)

#### Requirements

Write a program which allows to do these tasks:

1. Search bills by using `MaPT` (Bill ID), `NgayThu` (Day of Bills), `SoTien` (Money), `LyDoThu` (Reason), `GhiChu` (Notice)
2. Can update/detele/update bills.
3. The program allows inputs as user information

#### Guide
##### Main interface
* The program will start with a login window. Fill correct information, and click `Log in` to connect to the `SQL Database` or `Exit` to quit the program.

  * ![Login interface](../../../images/bill1.PNG "Login interface")

* Abbreviation
  * `Phiếu thu' = `Bills` : Open Bills form
  * `Tìm kiếm` = `Search` : Open Search form
  * `Thông tin` = `Information` : Open Information form 
  * `Quản Lý Phiếu Thu` = `Bill management system`

