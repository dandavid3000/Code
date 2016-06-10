
Use [QuanLyHocSinhPTNK]
Go
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Khoi_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Khoi_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Khoi_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets all records from the Khoi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Khoi_Get_List

AS


				
				SELECT
					[MaKhoi],
					[TenKhoi]
				FROM
					[dbo].[Khoi]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Khoi_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Khoi_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Khoi_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets records from the Khoi table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Khoi_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MaKhoi]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MaKhoi]'
				SET @SQL = @SQL + ', [TenKhoi]'
				SET @SQL = @SQL + ' FROM [dbo].[Khoi]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaKhoi],'
				SET @SQL = @SQL + ' [TenKhoi]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Khoi]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Khoi_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Khoi_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Khoi_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Inserts a record into the Khoi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Khoi_Insert
(

	@MaKhoi nchar (10)  ,

	@TenKhoi nvarchar (50)  
)
AS


					
				INSERT INTO [dbo].[Khoi]
					(
					[MaKhoi]
					,[TenKhoi]
					)
				VALUES
					(
					@MaKhoi
					,@TenKhoi
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Khoi_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Khoi_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Khoi_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Updates a record in the Khoi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Khoi_Update
(

	@MaKhoi nchar (10)  ,

	@OriginalMaKhoi nchar (10)  ,

	@TenKhoi nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Khoi]
				SET
					[MaKhoi] = @MaKhoi
					,[TenKhoi] = @TenKhoi
				WHERE
[MaKhoi] = @OriginalMaKhoi 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Khoi_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Khoi_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Khoi_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Deletes a record in the Khoi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Khoi_Delete
(

	@MaKhoi nchar (10)  
)
AS


				DELETE FROM [dbo].[Khoi] WITH (ROWLOCK) 
				WHERE
					[MaKhoi] = @MaKhoi
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Khoi_GetByMaKhoi procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Khoi_GetByMaKhoi') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Khoi_GetByMaKhoi
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the Khoi table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Khoi_GetByMaKhoi
(

	@MaKhoi nchar (10)  
)
AS


				SELECT
					[MaKhoi],
					[TenKhoi]
				FROM
					[dbo].[Khoi]
				WHERE
					[MaKhoi] = @MaKhoi
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Khoi_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Khoi_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Khoi_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Finds records in the Khoi table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Khoi_Find
(

	@SearchUsingOR bit   = null ,

	@MaKhoi nchar (10)  = null ,

	@TenKhoi nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaKhoi]
	, [TenKhoi]
    FROM
	[dbo].[Khoi]
    WHERE 
	 ([MaKhoi] = @MaKhoi OR @MaKhoi is null)
	AND ([TenKhoi] = @TenKhoi OR @TenKhoi is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaKhoi]
	, [TenKhoi]
    FROM
	[dbo].[Khoi]
    WHERE 
	 ([MaKhoi] = @MaKhoi AND @MaKhoi is not null)
	OR ([TenKhoi] = @TenKhoi AND @TenKhoi is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhongBan_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhongBan_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhongBan_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets all records from the PhongBan table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhongBan_Get_List

AS


				
				SELECT
					[MaPhongBan],
					[TenPhongBan]
				FROM
					[dbo].[PhongBan]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhongBan_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhongBan_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhongBan_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets records from the PhongBan table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhongBan_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MaPhongBan]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MaPhongBan]'
				SET @SQL = @SQL + ', [TenPhongBan]'
				SET @SQL = @SQL + ' FROM [dbo].[PhongBan]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaPhongBan],'
				SET @SQL = @SQL + ' [TenPhongBan]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[PhongBan]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhongBan_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhongBan_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhongBan_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Inserts a record into the PhongBan table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhongBan_Insert
(

	@MaPhongBan nchar (10)  ,

	@TenPhongBan nvarchar (50)  
)
AS


					
				INSERT INTO [dbo].[PhongBan]
					(
					[MaPhongBan]
					,[TenPhongBan]
					)
				VALUES
					(
					@MaPhongBan
					,@TenPhongBan
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhongBan_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhongBan_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhongBan_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Updates a record in the PhongBan table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhongBan_Update
(

	@MaPhongBan nchar (10)  ,

	@OriginalMaPhongBan nchar (10)  ,

	@TenPhongBan nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[PhongBan]
				SET
					[MaPhongBan] = @MaPhongBan
					,[TenPhongBan] = @TenPhongBan
				WHERE
[MaPhongBan] = @OriginalMaPhongBan 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhongBan_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhongBan_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhongBan_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Deletes a record in the PhongBan table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhongBan_Delete
(

	@MaPhongBan nchar (10)  
)
AS


				DELETE FROM [dbo].[PhongBan] WITH (ROWLOCK) 
				WHERE
					[MaPhongBan] = @MaPhongBan
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhongBan_GetByMaPhongBan procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhongBan_GetByMaPhongBan') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhongBan_GetByMaPhongBan
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the PhongBan table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhongBan_GetByMaPhongBan
(

	@MaPhongBan nchar (10)  
)
AS


				SELECT
					[MaPhongBan],
					[TenPhongBan]
				FROM
					[dbo].[PhongBan]
				WHERE
					[MaPhongBan] = @MaPhongBan
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhongBan_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhongBan_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhongBan_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Finds records in the PhongBan table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhongBan_Find
(

	@SearchUsingOR bit   = null ,

	@MaPhongBan nchar (10)  = null ,

	@TenPhongBan nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaPhongBan]
	, [TenPhongBan]
    FROM
	[dbo].[PhongBan]
    WHERE 
	 ([MaPhongBan] = @MaPhongBan OR @MaPhongBan is null)
	AND ([TenPhongBan] = @TenPhongBan OR @TenPhongBan is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaPhongBan]
	, [TenPhongBan]
    FROM
	[dbo].[PhongBan]
    WHERE 
	 ([MaPhongBan] = @MaPhongBan AND @MaPhongBan is not null)
	OR ([TenPhongBan] = @TenPhongBan AND @TenPhongBan is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocSinh_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocSinh_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocSinh_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets all records from the HocSinh table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocSinh_Get_List

AS


				
				SELECT
					[MaHocSinh],
					[HoTenHocSinh],
					[GioiTinh],
					[NgaySinh],
					[DiaChi],
					[Email],
					[XepLoai],
					[HanhKiem],
					[Password],
					[MaLop]
				FROM
					[dbo].[HocSinh]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocSinh_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocSinh_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocSinh_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets records from the HocSinh table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocSinh_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MaHocSinh]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MaHocSinh]'
				SET @SQL = @SQL + ', [HoTenHocSinh]'
				SET @SQL = @SQL + ', [GioiTinh]'
				SET @SQL = @SQL + ', [NgaySinh]'
				SET @SQL = @SQL + ', [DiaChi]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [XepLoai]'
				SET @SQL = @SQL + ', [HanhKiem]'
				SET @SQL = @SQL + ', [Password]'
				SET @SQL = @SQL + ', [MaLop]'
				SET @SQL = @SQL + ' FROM [dbo].[HocSinh]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaHocSinh],'
				SET @SQL = @SQL + ' [HoTenHocSinh],'
				SET @SQL = @SQL + ' [GioiTinh],'
				SET @SQL = @SQL + ' [NgaySinh],'
				SET @SQL = @SQL + ' [DiaChi],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [XepLoai],'
				SET @SQL = @SQL + ' [HanhKiem],'
				SET @SQL = @SQL + ' [Password],'
				SET @SQL = @SQL + ' [MaLop]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[HocSinh]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocSinh_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocSinh_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocSinh_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Inserts a record into the HocSinh table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocSinh_Insert
(

	@MaHocSinh nchar (10)  ,

	@HoTenHocSinh nvarchar (50)  ,

	@GioiTinh nvarchar (50)  ,

	@NgaySinh datetime   ,

	@DiaChi nvarchar (50)  ,

	@Email text   ,

	@XepLoai nvarchar (50)  ,

	@HanhKiem nvarchar (50)  ,

	@Password nchar (10)  ,

	@MaLop nchar (10)  
)
AS


					
				INSERT INTO [dbo].[HocSinh]
					(
					[MaHocSinh]
					,[HoTenHocSinh]
					,[GioiTinh]
					,[NgaySinh]
					,[DiaChi]
					,[Email]
					,[XepLoai]
					,[HanhKiem]
					,[Password]
					,[MaLop]
					)
				VALUES
					(
					@MaHocSinh
					,@HoTenHocSinh
					,@GioiTinh
					,@NgaySinh
					,@DiaChi
					,@Email
					,@XepLoai
					,@HanhKiem
					,@Password
					,@MaLop
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocSinh_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocSinh_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocSinh_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Updates a record in the HocSinh table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocSinh_Update
(

	@MaHocSinh nchar (10)  ,

	@OriginalMaHocSinh nchar (10)  ,

	@HoTenHocSinh nvarchar (50)  ,

	@GioiTinh nvarchar (50)  ,

	@NgaySinh datetime   ,

	@DiaChi nvarchar (50)  ,

	@Email text   ,

	@XepLoai nvarchar (50)  ,

	@HanhKiem nvarchar (50)  ,

	@Password nchar (10)  ,

	@MaLop nchar (10)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[HocSinh]
				SET
					[MaHocSinh] = @MaHocSinh
					,[HoTenHocSinh] = @HoTenHocSinh
					,[GioiTinh] = @GioiTinh
					,[NgaySinh] = @NgaySinh
					,[DiaChi] = @DiaChi
					,[Email] = @Email
					,[XepLoai] = @XepLoai
					,[HanhKiem] = @HanhKiem
					,[Password] = @Password
					,[MaLop] = @MaLop
				WHERE
[MaHocSinh] = @OriginalMaHocSinh 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocSinh_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocSinh_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocSinh_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Deletes a record in the HocSinh table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocSinh_Delete
(

	@MaHocSinh nchar (10)  
)
AS


				DELETE FROM [dbo].[HocSinh] WITH (ROWLOCK) 
				WHERE
					[MaHocSinh] = @MaHocSinh
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocSinh_GetByMaLop procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocSinh_GetByMaLop') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocSinh_GetByMaLop
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the HocSinh table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocSinh_GetByMaLop
(

	@MaLop nchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MaHocSinh],
					[HoTenHocSinh],
					[GioiTinh],
					[NgaySinh],
					[DiaChi],
					[Email],
					[XepLoai],
					[HanhKiem],
					[Password],
					[MaLop]
				FROM
					[dbo].[HocSinh]
				WHERE
					[MaLop] = @MaLop
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocSinh_GetByMaHocSinh procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocSinh_GetByMaHocSinh') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocSinh_GetByMaHocSinh
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the HocSinh table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocSinh_GetByMaHocSinh
(

	@MaHocSinh nchar (10)  
)
AS


				SELECT
					[MaHocSinh],
					[HoTenHocSinh],
					[GioiTinh],
					[NgaySinh],
					[DiaChi],
					[Email],
					[XepLoai],
					[HanhKiem],
					[Password],
					[MaLop]
				FROM
					[dbo].[HocSinh]
				WHERE
					[MaHocSinh] = @MaHocSinh
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocSinh_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocSinh_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocSinh_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Finds records in the HocSinh table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocSinh_Find
(

	@SearchUsingOR bit   = null ,

	@MaHocSinh nchar (10)  = null ,

	@HoTenHocSinh nvarchar (50)  = null ,

	@GioiTinh nvarchar (50)  = null ,

	@NgaySinh datetime   = null ,

	@DiaChi nvarchar (50)  = null ,

	@Email text   = null ,

	@XepLoai nvarchar (50)  = null ,

	@HanhKiem nvarchar (50)  = null ,

	@Password nchar (10)  = null ,

	@MaLop nchar (10)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaHocSinh]
	, [HoTenHocSinh]
	, [GioiTinh]
	, [NgaySinh]
	, [DiaChi]
	, [Email]
	, [XepLoai]
	, [HanhKiem]
	, [Password]
	, [MaLop]
    FROM
	[dbo].[HocSinh]
    WHERE 
	 ([MaHocSinh] = @MaHocSinh OR @MaHocSinh is null)
	AND ([HoTenHocSinh] = @HoTenHocSinh OR @HoTenHocSinh is null)
	AND ([GioiTinh] = @GioiTinh OR @GioiTinh is null)
	AND ([NgaySinh] = @NgaySinh OR @NgaySinh is null)
	AND ([DiaChi] = @DiaChi OR @DiaChi is null)
	AND ([XepLoai] = @XepLoai OR @XepLoai is null)
	AND ([HanhKiem] = @HanhKiem OR @HanhKiem is null)
	AND ([Password] = @Password OR @Password is null)
	AND ([MaLop] = @MaLop OR @MaLop is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaHocSinh]
	, [HoTenHocSinh]
	, [GioiTinh]
	, [NgaySinh]
	, [DiaChi]
	, [Email]
	, [XepLoai]
	, [HanhKiem]
	, [Password]
	, [MaLop]
    FROM
	[dbo].[HocSinh]
    WHERE 
	 ([MaHocSinh] = @MaHocSinh AND @MaHocSinh is not null)
	OR ([HoTenHocSinh] = @HoTenHocSinh AND @HoTenHocSinh is not null)
	OR ([GioiTinh] = @GioiTinh AND @GioiTinh is not null)
	OR ([NgaySinh] = @NgaySinh AND @NgaySinh is not null)
	OR ([DiaChi] = @DiaChi AND @DiaChi is not null)
	OR ([XepLoai] = @XepLoai AND @XepLoai is not null)
	OR ([HanhKiem] = @HanhKiem AND @HanhKiem is not null)
	OR ([Password] = @Password AND @Password is not null)
	OR ([MaLop] = @MaLop AND @MaLop is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LopHoc_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LopHoc_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LopHoc_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets all records from the LopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_Get_List

AS


				
				SELECT
					[MaLop],
					[TenLop],
					[MaKhoi]
				FROM
					[dbo].[LopHoc]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LopHoc_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LopHoc_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LopHoc_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets records from the LopHoc table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MaLop]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MaLop]'
				SET @SQL = @SQL + ', [TenLop]'
				SET @SQL = @SQL + ', [MaKhoi]'
				SET @SQL = @SQL + ' FROM [dbo].[LopHoc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaLop],'
				SET @SQL = @SQL + ' [TenLop],'
				SET @SQL = @SQL + ' [MaKhoi]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[LopHoc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LopHoc_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LopHoc_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LopHoc_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Inserts a record into the LopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_Insert
(

	@MaLop nchar (10)  ,

	@TenLop nvarchar (50)  ,

	@MaKhoi nchar (10)  
)
AS


					
				INSERT INTO [dbo].[LopHoc]
					(
					[MaLop]
					,[TenLop]
					,[MaKhoi]
					)
				VALUES
					(
					@MaLop
					,@TenLop
					,@MaKhoi
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LopHoc_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LopHoc_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LopHoc_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Updates a record in the LopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_Update
(

	@MaLop nchar (10)  ,

	@OriginalMaLop nchar (10)  ,

	@TenLop nvarchar (50)  ,

	@MaKhoi nchar (10)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[LopHoc]
				SET
					[MaLop] = @MaLop
					,[TenLop] = @TenLop
					,[MaKhoi] = @MaKhoi
				WHERE
[MaLop] = @OriginalMaLop 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LopHoc_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LopHoc_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LopHoc_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Deletes a record in the LopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_Delete
(

	@MaLop nchar (10)  
)
AS


				DELETE FROM [dbo].[LopHoc] WITH (ROWLOCK) 
				WHERE
					[MaLop] = @MaLop
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LopHoc_GetByMaKhoi procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LopHoc_GetByMaKhoi') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LopHoc_GetByMaKhoi
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the LopHoc table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_GetByMaKhoi
(

	@MaKhoi nchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MaLop],
					[TenLop],
					[MaKhoi]
				FROM
					[dbo].[LopHoc]
				WHERE
					[MaKhoi] = @MaKhoi
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LopHoc_GetByMaLop procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LopHoc_GetByMaLop') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LopHoc_GetByMaLop
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the LopHoc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_GetByMaLop
(

	@MaLop nchar (10)  
)
AS


				SELECT
					[MaLop],
					[TenLop],
					[MaKhoi]
				FROM
					[dbo].[LopHoc]
				WHERE
					[MaLop] = @MaLop
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LopHoc_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LopHoc_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LopHoc_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Finds records in the LopHoc table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_Find
(

	@SearchUsingOR bit   = null ,

	@MaLop nchar (10)  = null ,

	@TenLop nvarchar (50)  = null ,

	@MaKhoi nchar (10)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaLop]
	, [TenLop]
	, [MaKhoi]
    FROM
	[dbo].[LopHoc]
    WHERE 
	 ([MaLop] = @MaLop OR @MaLop is null)
	AND ([TenLop] = @TenLop OR @TenLop is null)
	AND ([MaKhoi] = @MaKhoi OR @MaKhoi is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaLop]
	, [TenLop]
	, [MaKhoi]
    FROM
	[dbo].[LopHoc]
    WHERE 
	 ([MaLop] = @MaLop AND @MaLop is not null)
	OR ([TenLop] = @TenLop AND @TenLop is not null)
	OR ([MaKhoi] = @MaKhoi AND @MaKhoi is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuanLy_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuanLy_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuanLy_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets all records from the QuanLy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuanLy_Get_List

AS


				
				SELECT
					[MaQuanLy],
					[HoTenQuanLy],
					[Password],
					[MaChucDanh],
					[MaPhongBan]
				FROM
					[dbo].[QuanLy]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuanLy_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuanLy_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuanLy_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets records from the QuanLy table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuanLy_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MaQuanLy]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MaQuanLy]'
				SET @SQL = @SQL + ', [HoTenQuanLy]'
				SET @SQL = @SQL + ', [Password]'
				SET @SQL = @SQL + ', [MaChucDanh]'
				SET @SQL = @SQL + ', [MaPhongBan]'
				SET @SQL = @SQL + ' FROM [dbo].[QuanLy]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaQuanLy],'
				SET @SQL = @SQL + ' [HoTenQuanLy],'
				SET @SQL = @SQL + ' [Password],'
				SET @SQL = @SQL + ' [MaChucDanh],'
				SET @SQL = @SQL + ' [MaPhongBan]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[QuanLy]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuanLy_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuanLy_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuanLy_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Inserts a record into the QuanLy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuanLy_Insert
(

	@MaQuanLy nchar (10)  ,

	@HoTenQuanLy nvarchar (50)  ,

	@Password nchar (10)  ,

	@MaChucDanh nchar (10)  ,

	@MaPhongBan nchar (10)  
)
AS


					
				INSERT INTO [dbo].[QuanLy]
					(
					[MaQuanLy]
					,[HoTenQuanLy]
					,[Password]
					,[MaChucDanh]
					,[MaPhongBan]
					)
				VALUES
					(
					@MaQuanLy
					,@HoTenQuanLy
					,@Password
					,@MaChucDanh
					,@MaPhongBan
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuanLy_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuanLy_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuanLy_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Updates a record in the QuanLy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuanLy_Update
(

	@MaQuanLy nchar (10)  ,

	@OriginalMaQuanLy nchar (10)  ,

	@HoTenQuanLy nvarchar (50)  ,

	@Password nchar (10)  ,

	@MaChucDanh nchar (10)  ,

	@MaPhongBan nchar (10)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[QuanLy]
				SET
					[MaQuanLy] = @MaQuanLy
					,[HoTenQuanLy] = @HoTenQuanLy
					,[Password] = @Password
					,[MaChucDanh] = @MaChucDanh
					,[MaPhongBan] = @MaPhongBan
				WHERE
[MaQuanLy] = @OriginalMaQuanLy 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuanLy_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuanLy_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuanLy_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Deletes a record in the QuanLy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuanLy_Delete
(

	@MaQuanLy nchar (10)  
)
AS


				DELETE FROM [dbo].[QuanLy] WITH (ROWLOCK) 
				WHERE
					[MaQuanLy] = @MaQuanLy
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuanLy_GetByMaChucDanh procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuanLy_GetByMaChucDanh') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuanLy_GetByMaChucDanh
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the QuanLy table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuanLy_GetByMaChucDanh
(

	@MaChucDanh nchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MaQuanLy],
					[HoTenQuanLy],
					[Password],
					[MaChucDanh],
					[MaPhongBan]
				FROM
					[dbo].[QuanLy]
				WHERE
					[MaChucDanh] = @MaChucDanh
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuanLy_GetByMaPhongBan procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuanLy_GetByMaPhongBan') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuanLy_GetByMaPhongBan
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the QuanLy table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuanLy_GetByMaPhongBan
(

	@MaPhongBan nchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MaQuanLy],
					[HoTenQuanLy],
					[Password],
					[MaChucDanh],
					[MaPhongBan]
				FROM
					[dbo].[QuanLy]
				WHERE
					[MaPhongBan] = @MaPhongBan
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuanLy_GetByMaQuanLy procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuanLy_GetByMaQuanLy') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuanLy_GetByMaQuanLy
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the QuanLy table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuanLy_GetByMaQuanLy
(

	@MaQuanLy nchar (10)  
)
AS


				SELECT
					[MaQuanLy],
					[HoTenQuanLy],
					[Password],
					[MaChucDanh],
					[MaPhongBan]
				FROM
					[dbo].[QuanLy]
				WHERE
					[MaQuanLy] = @MaQuanLy
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QuanLy_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QuanLy_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QuanLy_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Finds records in the QuanLy table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QuanLy_Find
(

	@SearchUsingOR bit   = null ,

	@MaQuanLy nchar (10)  = null ,

	@HoTenQuanLy nvarchar (50)  = null ,

	@Password nchar (10)  = null ,

	@MaChucDanh nchar (10)  = null ,

	@MaPhongBan nchar (10)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaQuanLy]
	, [HoTenQuanLy]
	, [Password]
	, [MaChucDanh]
	, [MaPhongBan]
    FROM
	[dbo].[QuanLy]
    WHERE 
	 ([MaQuanLy] = @MaQuanLy OR @MaQuanLy is null)
	AND ([HoTenQuanLy] = @HoTenQuanLy OR @HoTenQuanLy is null)
	AND ([Password] = @Password OR @Password is null)
	AND ([MaChucDanh] = @MaChucDanh OR @MaChucDanh is null)
	AND ([MaPhongBan] = @MaPhongBan OR @MaPhongBan is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaQuanLy]
	, [HoTenQuanLy]
	, [Password]
	, [MaChucDanh]
	, [MaPhongBan]
    FROM
	[dbo].[QuanLy]
    WHERE 
	 ([MaQuanLy] = @MaQuanLy AND @MaQuanLy is not null)
	OR ([HoTenQuanLy] = @HoTenQuanLy AND @HoTenQuanLy is not null)
	OR ([Password] = @Password AND @Password is not null)
	OR ([MaChucDanh] = @MaChucDanh AND @MaChucDanh is not null)
	OR ([MaPhongBan] = @MaPhongBan AND @MaPhongBan is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.MonHoc_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.MonHoc_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.MonHoc_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets all records from the MonHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.MonHoc_Get_List

AS


				
				SELECT
					[MaMon],
					[TenMon]
				FROM
					[dbo].[MonHoc]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.MonHoc_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.MonHoc_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.MonHoc_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets records from the MonHoc table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.MonHoc_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MaMon]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MaMon]'
				SET @SQL = @SQL + ', [TenMon]'
				SET @SQL = @SQL + ' FROM [dbo].[MonHoc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaMon],'
				SET @SQL = @SQL + ' [TenMon]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[MonHoc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.MonHoc_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.MonHoc_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.MonHoc_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Inserts a record into the MonHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.MonHoc_Insert
(

	@MaMon nchar (10)  ,

	@TenMon nvarchar (50)  
)
AS


					
				INSERT INTO [dbo].[MonHoc]
					(
					[MaMon]
					,[TenMon]
					)
				VALUES
					(
					@MaMon
					,@TenMon
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.MonHoc_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.MonHoc_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.MonHoc_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Updates a record in the MonHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.MonHoc_Update
(

	@MaMon nchar (10)  ,

	@OriginalMaMon nchar (10)  ,

	@TenMon nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[MonHoc]
				SET
					[MaMon] = @MaMon
					,[TenMon] = @TenMon
				WHERE
[MaMon] = @OriginalMaMon 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.MonHoc_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.MonHoc_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.MonHoc_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Deletes a record in the MonHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.MonHoc_Delete
(

	@MaMon nchar (10)  
)
AS


				DELETE FROM [dbo].[MonHoc] WITH (ROWLOCK) 
				WHERE
					[MaMon] = @MaMon
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.MonHoc_GetByMaMon procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.MonHoc_GetByMaMon') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.MonHoc_GetByMaMon
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the MonHoc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.MonHoc_GetByMaMon
(

	@MaMon nchar (10)  
)
AS


				SELECT
					[MaMon],
					[TenMon]
				FROM
					[dbo].[MonHoc]
				WHERE
					[MaMon] = @MaMon
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.MonHoc_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.MonHoc_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.MonHoc_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Finds records in the MonHoc table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.MonHoc_Find
(

	@SearchUsingOR bit   = null ,

	@MaMon nchar (10)  = null ,

	@TenMon nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaMon]
	, [TenMon]
    FROM
	[dbo].[MonHoc]
    WHERE 
	 ([MaMon] = @MaMon OR @MaMon is null)
	AND ([TenMon] = @TenMon OR @TenMon is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaMon]
	, [TenMon]
    FROM
	[dbo].[MonHoc]
    WHERE 
	 ([MaMon] = @MaMon AND @MaMon is not null)
	OR ([TenMon] = @TenMon AND @TenMon is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangThamSo_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangThamSo_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangThamSo_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets all records from the BangThamSo table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangThamSo_Get_List

AS


				
				SELECT
					[MaBangThamSo],
					[SoTuoiToiThieu],
					[SoTuoiToiDa],
					[SiSoToiDa],
					[SoMonHoc],
					[DiemChuan],
					[SoQuanLyToiDa],
					[SoTietHocLienTiep]
				FROM
					[dbo].[BangThamSo]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangThamSo_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangThamSo_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangThamSo_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets records from the BangThamSo table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangThamSo_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MaBangThamSo]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MaBangThamSo]'
				SET @SQL = @SQL + ', [SoTuoiToiThieu]'
				SET @SQL = @SQL + ', [SoTuoiToiDa]'
				SET @SQL = @SQL + ', [SiSoToiDa]'
				SET @SQL = @SQL + ', [SoMonHoc]'
				SET @SQL = @SQL + ', [DiemChuan]'
				SET @SQL = @SQL + ', [SoQuanLyToiDa]'
				SET @SQL = @SQL + ', [SoTietHocLienTiep]'
				SET @SQL = @SQL + ' FROM [dbo].[BangThamSo]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaBangThamSo],'
				SET @SQL = @SQL + ' [SoTuoiToiThieu],'
				SET @SQL = @SQL + ' [SoTuoiToiDa],'
				SET @SQL = @SQL + ' [SiSoToiDa],'
				SET @SQL = @SQL + ' [SoMonHoc],'
				SET @SQL = @SQL + ' [DiemChuan],'
				SET @SQL = @SQL + ' [SoQuanLyToiDa],'
				SET @SQL = @SQL + ' [SoTietHocLienTiep]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[BangThamSo]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangThamSo_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangThamSo_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangThamSo_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Inserts a record into the BangThamSo table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangThamSo_Insert
(

	@MaBangThamSo nchar (10)  ,

	@SoTuoiToiThieu int   ,

	@SoTuoiToiDa int   ,

	@SiSoToiDa int   ,

	@SoMonHoc int   ,

	@DiemChuan float   ,

	@SoQuanLyToiDa int   ,

	@SoTietHocLienTiep int   
)
AS


					
				INSERT INTO [dbo].[BangThamSo]
					(
					[MaBangThamSo]
					,[SoTuoiToiThieu]
					,[SoTuoiToiDa]
					,[SiSoToiDa]
					,[SoMonHoc]
					,[DiemChuan]
					,[SoQuanLyToiDa]
					,[SoTietHocLienTiep]
					)
				VALUES
					(
					@MaBangThamSo
					,@SoTuoiToiThieu
					,@SoTuoiToiDa
					,@SiSoToiDa
					,@SoMonHoc
					,@DiemChuan
					,@SoQuanLyToiDa
					,@SoTietHocLienTiep
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangThamSo_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangThamSo_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangThamSo_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Updates a record in the BangThamSo table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangThamSo_Update
(

	@MaBangThamSo nchar (10)  ,

	@OriginalMaBangThamSo nchar (10)  ,

	@SoTuoiToiThieu int   ,

	@SoTuoiToiDa int   ,

	@SiSoToiDa int   ,

	@SoMonHoc int   ,

	@DiemChuan float   ,

	@SoQuanLyToiDa int   ,

	@SoTietHocLienTiep int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[BangThamSo]
				SET
					[MaBangThamSo] = @MaBangThamSo
					,[SoTuoiToiThieu] = @SoTuoiToiThieu
					,[SoTuoiToiDa] = @SoTuoiToiDa
					,[SiSoToiDa] = @SiSoToiDa
					,[SoMonHoc] = @SoMonHoc
					,[DiemChuan] = @DiemChuan
					,[SoQuanLyToiDa] = @SoQuanLyToiDa
					,[SoTietHocLienTiep] = @SoTietHocLienTiep
				WHERE
[MaBangThamSo] = @OriginalMaBangThamSo 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangThamSo_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangThamSo_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangThamSo_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Deletes a record in the BangThamSo table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangThamSo_Delete
(

	@MaBangThamSo nchar (10)  
)
AS


				DELETE FROM [dbo].[BangThamSo] WITH (ROWLOCK) 
				WHERE
					[MaBangThamSo] = @MaBangThamSo
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangThamSo_GetByMaBangThamSo procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangThamSo_GetByMaBangThamSo') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangThamSo_GetByMaBangThamSo
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the BangThamSo table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangThamSo_GetByMaBangThamSo
(

	@MaBangThamSo nchar (10)  
)
AS


				SELECT
					[MaBangThamSo],
					[SoTuoiToiThieu],
					[SoTuoiToiDa],
					[SiSoToiDa],
					[SoMonHoc],
					[DiemChuan],
					[SoQuanLyToiDa],
					[SoTietHocLienTiep]
				FROM
					[dbo].[BangThamSo]
				WHERE
					[MaBangThamSo] = @MaBangThamSo
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangThamSo_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangThamSo_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangThamSo_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Finds records in the BangThamSo table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangThamSo_Find
(

	@SearchUsingOR bit   = null ,

	@MaBangThamSo nchar (10)  = null ,

	@SoTuoiToiThieu int   = null ,

	@SoTuoiToiDa int   = null ,

	@SiSoToiDa int   = null ,

	@SoMonHoc int   = null ,

	@DiemChuan float   = null ,

	@SoQuanLyToiDa int   = null ,

	@SoTietHocLienTiep int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaBangThamSo]
	, [SoTuoiToiThieu]
	, [SoTuoiToiDa]
	, [SiSoToiDa]
	, [SoMonHoc]
	, [DiemChuan]
	, [SoQuanLyToiDa]
	, [SoTietHocLienTiep]
    FROM
	[dbo].[BangThamSo]
    WHERE 
	 ([MaBangThamSo] = @MaBangThamSo OR @MaBangThamSo is null)
	AND ([SoTuoiToiThieu] = @SoTuoiToiThieu OR @SoTuoiToiThieu is null)
	AND ([SoTuoiToiDa] = @SoTuoiToiDa OR @SoTuoiToiDa is null)
	AND ([SiSoToiDa] = @SiSoToiDa OR @SiSoToiDa is null)
	AND ([SoMonHoc] = @SoMonHoc OR @SoMonHoc is null)
	AND ([DiemChuan] = @DiemChuan OR @DiemChuan is null)
	AND ([SoQuanLyToiDa] = @SoQuanLyToiDa OR @SoQuanLyToiDa is null)
	AND ([SoTietHocLienTiep] = @SoTietHocLienTiep OR @SoTietHocLienTiep is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaBangThamSo]
	, [SoTuoiToiThieu]
	, [SoTuoiToiDa]
	, [SiSoToiDa]
	, [SoMonHoc]
	, [DiemChuan]
	, [SoQuanLyToiDa]
	, [SoTietHocLienTiep]
    FROM
	[dbo].[BangThamSo]
    WHERE 
	 ([MaBangThamSo] = @MaBangThamSo AND @MaBangThamSo is not null)
	OR ([SoTuoiToiThieu] = @SoTuoiToiThieu AND @SoTuoiToiThieu is not null)
	OR ([SoTuoiToiDa] = @SoTuoiToiDa AND @SoTuoiToiDa is not null)
	OR ([SiSoToiDa] = @SiSoToiDa AND @SiSoToiDa is not null)
	OR ([SoMonHoc] = @SoMonHoc AND @SoMonHoc is not null)
	OR ([DiemChuan] = @DiemChuan AND @DiemChuan is not null)
	OR ([SoQuanLyToiDa] = @SoQuanLyToiDa AND @SoQuanLyToiDa is not null)
	OR ([SoTietHocLienTiep] = @SoTietHocLienTiep AND @SoTietHocLienTiep is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangDiem_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangDiem_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangDiem_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets all records from the BangDiem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangDiem_Get_List

AS


				
				SELECT
					[MaBangDiem],
					[DTB],
					[MaHocSinh]
				FROM
					[dbo].[BangDiem]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangDiem_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangDiem_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangDiem_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets records from the BangDiem table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangDiem_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MaBangDiem]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MaBangDiem]'
				SET @SQL = @SQL + ', [DTB]'
				SET @SQL = @SQL + ', [MaHocSinh]'
				SET @SQL = @SQL + ' FROM [dbo].[BangDiem]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaBangDiem],'
				SET @SQL = @SQL + ' [DTB],'
				SET @SQL = @SQL + ' [MaHocSinh]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[BangDiem]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangDiem_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangDiem_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangDiem_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Inserts a record into the BangDiem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangDiem_Insert
(

	@MaBangDiem nchar (10)  ,

	@Dtb float   ,

	@MaHocSinh nchar (10)  
)
AS


					
				INSERT INTO [dbo].[BangDiem]
					(
					[MaBangDiem]
					,[DTB]
					,[MaHocSinh]
					)
				VALUES
					(
					@MaBangDiem
					,@Dtb
					,@MaHocSinh
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangDiem_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangDiem_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangDiem_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Updates a record in the BangDiem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangDiem_Update
(

	@MaBangDiem nchar (10)  ,

	@OriginalMaBangDiem nchar (10)  ,

	@Dtb float   ,

	@MaHocSinh nchar (10)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[BangDiem]
				SET
					[MaBangDiem] = @MaBangDiem
					,[DTB] = @Dtb
					,[MaHocSinh] = @MaHocSinh
				WHERE
[MaBangDiem] = @OriginalMaBangDiem 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangDiem_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangDiem_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangDiem_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Deletes a record in the BangDiem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangDiem_Delete
(

	@MaBangDiem nchar (10)  
)
AS


				DELETE FROM [dbo].[BangDiem] WITH (ROWLOCK) 
				WHERE
					[MaBangDiem] = @MaBangDiem
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangDiem_GetByMaHocSinh procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangDiem_GetByMaHocSinh') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangDiem_GetByMaHocSinh
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the BangDiem table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangDiem_GetByMaHocSinh
(

	@MaHocSinh nchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MaBangDiem],
					[DTB],
					[MaHocSinh]
				FROM
					[dbo].[BangDiem]
				WHERE
					[MaHocSinh] = @MaHocSinh
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangDiem_GetByMaBangDiem procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangDiem_GetByMaBangDiem') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangDiem_GetByMaBangDiem
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the BangDiem table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangDiem_GetByMaBangDiem
(

	@MaBangDiem nchar (10)  
)
AS


				SELECT
					[MaBangDiem],
					[DTB],
					[MaHocSinh]
				FROM
					[dbo].[BangDiem]
				WHERE
					[MaBangDiem] = @MaBangDiem
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BangDiem_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BangDiem_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BangDiem_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Finds records in the BangDiem table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BangDiem_Find
(

	@SearchUsingOR bit   = null ,

	@MaBangDiem nchar (10)  = null ,

	@Dtb float   = null ,

	@MaHocSinh nchar (10)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaBangDiem]
	, [DTB]
	, [MaHocSinh]
    FROM
	[dbo].[BangDiem]
    WHERE 
	 ([MaBangDiem] = @MaBangDiem OR @MaBangDiem is null)
	AND ([DTB] = @Dtb OR @Dtb is null)
	AND ([MaHocSinh] = @MaHocSinh OR @MaHocSinh is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaBangDiem]
	, [DTB]
	, [MaHocSinh]
    FROM
	[dbo].[BangDiem]
    WHERE 
	 ([MaBangDiem] = @MaBangDiem AND @MaBangDiem is not null)
	OR ([DTB] = @Dtb AND @Dtb is not null)
	OR ([MaHocSinh] = @MaHocSinh AND @MaHocSinh is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ChucDanh_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ChucDanh_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ChucDanh_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets all records from the ChucDanh table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ChucDanh_Get_List

AS


				
				SELECT
					[MaChucDanh],
					[TenChucDanh]
				FROM
					[dbo].[ChucDanh]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ChucDanh_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ChucDanh_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ChucDanh_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets records from the ChucDanh table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ChucDanh_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MaChucDanh]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MaChucDanh]'
				SET @SQL = @SQL + ', [TenChucDanh]'
				SET @SQL = @SQL + ' FROM [dbo].[ChucDanh]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaChucDanh],'
				SET @SQL = @SQL + ' [TenChucDanh]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ChucDanh]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ChucDanh_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ChucDanh_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ChucDanh_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Inserts a record into the ChucDanh table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ChucDanh_Insert
(

	@MaChucDanh nchar (10)  ,

	@TenChucDanh nvarchar (50)  
)
AS


					
				INSERT INTO [dbo].[ChucDanh]
					(
					[MaChucDanh]
					,[TenChucDanh]
					)
				VALUES
					(
					@MaChucDanh
					,@TenChucDanh
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ChucDanh_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ChucDanh_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ChucDanh_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Updates a record in the ChucDanh table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ChucDanh_Update
(

	@MaChucDanh nchar (10)  ,

	@OriginalMaChucDanh nchar (10)  ,

	@TenChucDanh nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ChucDanh]
				SET
					[MaChucDanh] = @MaChucDanh
					,[TenChucDanh] = @TenChucDanh
				WHERE
[MaChucDanh] = @OriginalMaChucDanh 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ChucDanh_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ChucDanh_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ChucDanh_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Deletes a record in the ChucDanh table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ChucDanh_Delete
(

	@MaChucDanh nchar (10)  
)
AS


				DELETE FROM [dbo].[ChucDanh] WITH (ROWLOCK) 
				WHERE
					[MaChucDanh] = @MaChucDanh
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ChucDanh_GetByMaChucDanh procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ChucDanh_GetByMaChucDanh') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ChucDanh_GetByMaChucDanh
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the ChucDanh table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ChucDanh_GetByMaChucDanh
(

	@MaChucDanh nchar (10)  
)
AS


				SELECT
					[MaChucDanh],
					[TenChucDanh]
				FROM
					[dbo].[ChucDanh]
				WHERE
					[MaChucDanh] = @MaChucDanh
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ChucDanh_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ChucDanh_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ChucDanh_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Finds records in the ChucDanh table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ChucDanh_Find
(

	@SearchUsingOR bit   = null ,

	@MaChucDanh nchar (10)  = null ,

	@TenChucDanh nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaChucDanh]
	, [TenChucDanh]
    FROM
	[dbo].[ChucDanh]
    WHERE 
	 ([MaChucDanh] = @MaChucDanh OR @MaChucDanh is null)
	AND ([TenChucDanh] = @TenChucDanh OR @TenChucDanh is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaChucDanh]
	, [TenChucDanh]
    FROM
	[dbo].[ChucDanh]
    WHERE 
	 ([MaChucDanh] = @MaChucDanh AND @MaChucDanh is not null)
	OR ([TenChucDanh] = @TenChucDanh AND @TenChucDanh is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocKy_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocKy_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocKy_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets all records from the HocKy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocKy_Get_List

AS


				
				SELECT
					[MaHocKy],
					[TenHocKy]
				FROM
					[dbo].[HocKy]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocKy_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocKy_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocKy_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets records from the HocKy table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocKy_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MaHocKy]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MaHocKy]'
				SET @SQL = @SQL + ', [TenHocKy]'
				SET @SQL = @SQL + ' FROM [dbo].[HocKy]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaHocKy],'
				SET @SQL = @SQL + ' [TenHocKy]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[HocKy]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocKy_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocKy_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocKy_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Inserts a record into the HocKy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocKy_Insert
(

	@MaHocKy nchar (10)  ,

	@TenHocKy nvarchar (50)  
)
AS


					
				INSERT INTO [dbo].[HocKy]
					(
					[MaHocKy]
					,[TenHocKy]
					)
				VALUES
					(
					@MaHocKy
					,@TenHocKy
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocKy_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocKy_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocKy_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Updates a record in the HocKy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocKy_Update
(

	@MaHocKy nchar (10)  ,

	@OriginalMaHocKy nchar (10)  ,

	@TenHocKy nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[HocKy]
				SET
					[MaHocKy] = @MaHocKy
					,[TenHocKy] = @TenHocKy
				WHERE
[MaHocKy] = @OriginalMaHocKy 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocKy_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocKy_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocKy_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Deletes a record in the HocKy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocKy_Delete
(

	@MaHocKy nchar (10)  
)
AS


				DELETE FROM [dbo].[HocKy] WITH (ROWLOCK) 
				WHERE
					[MaHocKy] = @MaHocKy
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocKy_GetByMaHocKy procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocKy_GetByMaHocKy') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocKy_GetByMaHocKy
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the HocKy table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocKy_GetByMaHocKy
(

	@MaHocKy nchar (10)  
)
AS


				SELECT
					[MaHocKy],
					[TenHocKy]
				FROM
					[dbo].[HocKy]
				WHERE
					[MaHocKy] = @MaHocKy
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.HocKy_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.HocKy_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.HocKy_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Finds records in the HocKy table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.HocKy_Find
(

	@SearchUsingOR bit   = null ,

	@MaHocKy nchar (10)  = null ,

	@TenHocKy nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaHocKy]
	, [TenHocKy]
    FROM
	[dbo].[HocKy]
    WHERE 
	 ([MaHocKy] = @MaHocKy OR @MaHocKy is null)
	AND ([TenHocKy] = @TenHocKy OR @TenHocKy is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaHocKy]
	, [TenHocKy]
    FROM
	[dbo].[HocKy]
    WHERE 
	 ([MaHocKy] = @MaHocKy AND @MaHocKy is not null)
	OR ([TenHocKy] = @TenHocKy AND @TenHocKy is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diem_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diem_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diem_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets all records from the Diem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diem_Get_List

AS


				
				SELECT
					[MaDiem],
					[Diem15Phut],
					[Diem1Tiet],
					[DiemCuoiKy],
					[DTB],
					[MaMon],
					[MaBangDiem],
					[MaHocKy]
				FROM
					[dbo].[Diem]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diem_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diem_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diem_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Gets records from the Diem table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diem_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy is null or LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MaDiem]'
				END

				-- SQL Server 2005 Paging
				declare @SQL as nvarchar(4000)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MaDiem]'
				SET @SQL = @SQL + ', [Diem15Phut]'
				SET @SQL = @SQL + ', [Diem1Tiet]'
				SET @SQL = @SQL + ', [DiemCuoiKy]'
				SET @SQL = @SQL + ', [DTB]'
				SET @SQL = @SQL + ', [MaMon]'
				SET @SQL = @SQL + ', [MaBangDiem]'
				SET @SQL = @SQL + ', [MaHocKy]'
				SET @SQL = @SQL + ' FROM [dbo].[Diem]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaDiem],'
				SET @SQL = @SQL + ' [Diem15Phut],'
				SET @SQL = @SQL + ' [Diem1Tiet],'
				SET @SQL = @SQL + ' [DiemCuoiKy],'
				SET @SQL = @SQL + ' [DTB],'
				SET @SQL = @SQL + ' [MaMon],'
				SET @SQL = @SQL + ' [MaBangDiem],'
				SET @SQL = @SQL + ' [MaHocKy]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				exec sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Diem]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diem_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diem_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diem_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Inserts a record into the Diem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diem_Insert
(

	@MaDiem nchar (10)  ,

	@Diem15Phut float   ,

	@Diem1Tiet float   ,

	@DiemCuoiKy float   ,

	@Dtb float   ,

	@MaMon nchar (10)  ,

	@MaBangDiem nchar (10)  ,

	@MaHocKy nchar (10)  
)
AS


					
				INSERT INTO [dbo].[Diem]
					(
					[MaDiem]
					,[Diem15Phut]
					,[Diem1Tiet]
					,[DiemCuoiKy]
					,[DTB]
					,[MaMon]
					,[MaBangDiem]
					,[MaHocKy]
					)
				VALUES
					(
					@MaDiem
					,@Diem15Phut
					,@Diem1Tiet
					,@DiemCuoiKy
					,@Dtb
					,@MaMon
					,@MaBangDiem
					,@MaHocKy
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diem_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diem_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diem_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Updates a record in the Diem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diem_Update
(

	@MaDiem nchar (10)  ,

	@OriginalMaDiem nchar (10)  ,

	@Diem15Phut float   ,

	@Diem1Tiet float   ,

	@DiemCuoiKy float   ,

	@Dtb float   ,

	@MaMon nchar (10)  ,

	@MaBangDiem nchar (10)  ,

	@MaHocKy nchar (10)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Diem]
				SET
					[MaDiem] = @MaDiem
					,[Diem15Phut] = @Diem15Phut
					,[Diem1Tiet] = @Diem1Tiet
					,[DiemCuoiKy] = @DiemCuoiKy
					,[DTB] = @Dtb
					,[MaMon] = @MaMon
					,[MaBangDiem] = @MaBangDiem
					,[MaHocKy] = @MaHocKy
				WHERE
[MaDiem] = @OriginalMaDiem 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diem_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diem_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diem_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Deletes a record in the Diem table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diem_Delete
(

	@MaDiem nchar (10)  
)
AS


				DELETE FROM [dbo].[Diem] WITH (ROWLOCK) 
				WHERE
					[MaDiem] = @MaDiem
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diem_GetByMaMon procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diem_GetByMaMon') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diem_GetByMaMon
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the Diem table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diem_GetByMaMon
(

	@MaMon nchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MaDiem],
					[Diem15Phut],
					[Diem1Tiet],
					[DiemCuoiKy],
					[DTB],
					[MaMon],
					[MaBangDiem],
					[MaHocKy]
				FROM
					[dbo].[Diem]
				WHERE
					[MaMon] = @MaMon
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diem_GetByMaHocKy procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diem_GetByMaHocKy') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diem_GetByMaHocKy
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the Diem table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diem_GetByMaHocKy
(

	@MaHocKy nchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MaDiem],
					[Diem15Phut],
					[Diem1Tiet],
					[DiemCuoiKy],
					[DTB],
					[MaMon],
					[MaBangDiem],
					[MaHocKy]
				FROM
					[dbo].[Diem]
				WHERE
					[MaHocKy] = @MaHocKy
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diem_GetByMaBangDiem procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diem_GetByMaBangDiem') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diem_GetByMaBangDiem
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the Diem table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diem_GetByMaBangDiem
(

	@MaBangDiem nchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MaDiem],
					[Diem15Phut],
					[Diem1Tiet],
					[DiemCuoiKy],
					[DTB],
					[MaMon],
					[MaBangDiem],
					[MaHocKy]
				FROM
					[dbo].[Diem]
				WHERE
					[MaBangDiem] = @MaBangDiem
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diem_GetByMaDiem procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diem_GetByMaDiem') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diem_GetByMaDiem
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Select records from the Diem table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diem_GetByMaDiem
(

	@MaDiem nchar (10)  
)
AS


				SELECT
					[MaDiem],
					[Diem15Phut],
					[Diem1Tiet],
					[DiemCuoiKy],
					[DTB],
					[MaMon],
					[MaBangDiem],
					[MaHocKy]
				FROM
					[dbo].[Diem]
				WHERE
					[MaDiem] = @MaDiem
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diem_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diem_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diem_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: NG Software ()
-- Purpose: Finds records in the Diem table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diem_Find
(

	@SearchUsingOR bit   = null ,

	@MaDiem nchar (10)  = null ,

	@Diem15Phut float   = null ,

	@Diem1Tiet float   = null ,

	@DiemCuoiKy float   = null ,

	@Dtb float   = null ,

	@MaMon nchar (10)  = null ,

	@MaBangDiem nchar (10)  = null ,

	@MaHocKy nchar (10)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaDiem]
	, [Diem15Phut]
	, [Diem1Tiet]
	, [DiemCuoiKy]
	, [DTB]
	, [MaMon]
	, [MaBangDiem]
	, [MaHocKy]
    FROM
	[dbo].[Diem]
    WHERE 
	 ([MaDiem] = @MaDiem OR @MaDiem is null)
	AND ([Diem15Phut] = @Diem15Phut OR @Diem15Phut is null)
	AND ([Diem1Tiet] = @Diem1Tiet OR @Diem1Tiet is null)
	AND ([DiemCuoiKy] = @DiemCuoiKy OR @DiemCuoiKy is null)
	AND ([DTB] = @Dtb OR @Dtb is null)
	AND ([MaMon] = @MaMon OR @MaMon is null)
	AND ([MaBangDiem] = @MaBangDiem OR @MaBangDiem is null)
	AND ([MaHocKy] = @MaHocKy OR @MaHocKy is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaDiem]
	, [Diem15Phut]
	, [Diem1Tiet]
	, [DiemCuoiKy]
	, [DTB]
	, [MaMon]
	, [MaBangDiem]
	, [MaHocKy]
    FROM
	[dbo].[Diem]
    WHERE 
	 ([MaDiem] = @MaDiem AND @MaDiem is not null)
	OR ([Diem15Phut] = @Diem15Phut AND @Diem15Phut is not null)
	OR ([Diem1Tiet] = @Diem1Tiet AND @Diem1Tiet is not null)
	OR ([DiemCuoiKy] = @DiemCuoiKy AND @DiemCuoiKy is not null)
	OR ([DTB] = @Dtb AND @Dtb is not null)
	OR ([MaMon] = @MaMon AND @MaMon is not null)
	OR ([MaBangDiem] = @MaBangDiem AND @MaBangDiem is not null)
	OR ([MaHocKy] = @MaHocKy AND @MaHocKy is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

