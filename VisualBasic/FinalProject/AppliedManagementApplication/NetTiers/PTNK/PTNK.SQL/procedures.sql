
Use [PTNK]
Go
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocLopHoc_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocLopHoc_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocLopHoc_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the RangBuocLopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocLopHoc_Get_List

AS


				
				SELECT
					[MaRangBuocLopHoc],
					[MaLopHoc],
					[Thu],
					[TietHoc],
					[TrangThai]
				FROM
					[dbo].[RangBuocLopHoc]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocLopHoc_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocLopHoc_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocLopHoc_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the RangBuocLopHoc table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocLopHoc_GetPaged
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
					SET @OrderBy = '[MaRangBuocLopHoc]'
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
				SET @SQL = @SQL + ', [MaRangBuocLopHoc]'
				SET @SQL = @SQL + ', [MaLopHoc]'
				SET @SQL = @SQL + ', [Thu]'
				SET @SQL = @SQL + ', [TietHoc]'
				SET @SQL = @SQL + ', [TrangThai]'
				SET @SQL = @SQL + ' FROM [dbo].[RangBuocLopHoc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaRangBuocLopHoc],'
				SET @SQL = @SQL + ' [MaLopHoc],'
				SET @SQL = @SQL + ' [Thu],'
				SET @SQL = @SQL + ' [TietHoc],'
				SET @SQL = @SQL + ' [TrangThai]'
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
				SET @SQL = @SQL + ' FROM [dbo].[RangBuocLopHoc]'
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

	

-- Drop the dbo.RangBuocLopHoc_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocLopHoc_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocLopHoc_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the RangBuocLopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocLopHoc_Insert
(

	@MaRangBuocLopHoc nvarchar (9)  ,

	@MaLopHoc nvarchar (4)  ,

	@Thu tinyint   ,

	@TietHoc tinyint   ,

	@TrangThai tinyint   
)
AS


					
				INSERT INTO [dbo].[RangBuocLopHoc]
					(
					[MaRangBuocLopHoc]
					,[MaLopHoc]
					,[Thu]
					,[TietHoc]
					,[TrangThai]
					)
				VALUES
					(
					@MaRangBuocLopHoc
					,@MaLopHoc
					,@Thu
					,@TietHoc
					,@TrangThai
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocLopHoc_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocLopHoc_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocLopHoc_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the RangBuocLopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocLopHoc_Update
(

	@MaRangBuocLopHoc nvarchar (9)  ,

	@OriginalMaRangBuocLopHoc nvarchar (9)  ,

	@MaLopHoc nvarchar (4)  ,

	@Thu tinyint   ,

	@TietHoc tinyint   ,

	@TrangThai tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[RangBuocLopHoc]
				SET
					[MaRangBuocLopHoc] = @MaRangBuocLopHoc
					,[MaLopHoc] = @MaLopHoc
					,[Thu] = @Thu
					,[TietHoc] = @TietHoc
					,[TrangThai] = @TrangThai
				WHERE
[MaRangBuocLopHoc] = @OriginalMaRangBuocLopHoc 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocLopHoc_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocLopHoc_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocLopHoc_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the RangBuocLopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocLopHoc_Delete
(

	@MaRangBuocLopHoc nvarchar (9)  
)
AS


				DELETE FROM [dbo].[RangBuocLopHoc] WITH (ROWLOCK) 
				WHERE
					[MaRangBuocLopHoc] = @MaRangBuocLopHoc
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocLopHoc_GetByMaRangBuocLopHoc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocLopHoc_GetByMaRangBuocLopHoc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocLopHoc_GetByMaRangBuocLopHoc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the RangBuocLopHoc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocLopHoc_GetByMaRangBuocLopHoc
(

	@MaRangBuocLopHoc nvarchar (9)  
)
AS


				SELECT
					[MaRangBuocLopHoc],
					[MaLopHoc],
					[Thu],
					[TietHoc],
					[TrangThai]
				FROM
					[dbo].[RangBuocLopHoc]
				WHERE
					[MaRangBuocLopHoc] = @MaRangBuocLopHoc
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocLopHoc_GetByMaLopHoc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocLopHoc_GetByMaLopHoc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocLopHoc_GetByMaLopHoc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the RangBuocLopHoc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocLopHoc_GetByMaLopHoc
(

	@MaLopHoc nvarchar (4)  
)
AS


				SELECT
					[MaRangBuocLopHoc],
					[MaLopHoc],
					[Thu],
					[TietHoc],
					[TrangThai]
				FROM
					[dbo].[RangBuocLopHoc]
				WHERE
					[MaLopHoc] = @MaLopHoc
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocLopHoc_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocLopHoc_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocLopHoc_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the RangBuocLopHoc table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocLopHoc_Find
(

	@SearchUsingOR bit   = null ,

	@MaRangBuocLopHoc nvarchar (9)  = null ,

	@MaLopHoc nvarchar (4)  = null ,

	@Thu tinyint   = null ,

	@TietHoc tinyint   = null ,

	@TrangThai tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaRangBuocLopHoc]
	, [MaLopHoc]
	, [Thu]
	, [TietHoc]
	, [TrangThai]
    FROM
	[dbo].[RangBuocLopHoc]
    WHERE 
	 ([MaRangBuocLopHoc] = @MaRangBuocLopHoc OR @MaRangBuocLopHoc is null)
	AND ([MaLopHoc] = @MaLopHoc OR @MaLopHoc is null)
	AND ([Thu] = @Thu OR @Thu is null)
	AND ([TietHoc] = @TietHoc OR @TietHoc is null)
	AND ([TrangThai] = @TrangThai OR @TrangThai is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaRangBuocLopHoc]
	, [MaLopHoc]
	, [Thu]
	, [TietHoc]
	, [TrangThai]
    FROM
	[dbo].[RangBuocLopHoc]
    WHERE 
	 ([MaRangBuocLopHoc] = @MaRangBuocLopHoc AND @MaRangBuocLopHoc is not null)
	OR ([MaLopHoc] = @MaLopHoc AND @MaLopHoc is not null)
	OR ([Thu] = @Thu AND @Thu is not null)
	OR ([TietHoc] = @TietHoc AND @TietHoc is not null)
	OR ([TrangThai] = @TrangThai AND @TrangThai is not null)
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

-- Created By:  ()
-- Purpose: Gets all records from the MonHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.MonHoc_Get_List

AS


				
				SELECT
					[MaMonHoc],
					[TenMonHoc],
					[QuiDinhSoTietHocLienTiepToiThieu],
					[QuiDinhSoTietHocLienTiepToiDa]
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

-- Created By:  ()
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
					SET @OrderBy = '[MaMonHoc]'
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
				SET @SQL = @SQL + ', [MaMonHoc]'
				SET @SQL = @SQL + ', [TenMonHoc]'
				SET @SQL = @SQL + ', [QuiDinhSoTietHocLienTiepToiThieu]'
				SET @SQL = @SQL + ', [QuiDinhSoTietHocLienTiepToiDa]'
				SET @SQL = @SQL + ' FROM [dbo].[MonHoc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaMonHoc],'
				SET @SQL = @SQL + ' [TenMonHoc],'
				SET @SQL = @SQL + ' [QuiDinhSoTietHocLienTiepToiThieu],'
				SET @SQL = @SQL + ' [QuiDinhSoTietHocLienTiepToiDa]'
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

-- Created By:  ()
-- Purpose: Inserts a record into the MonHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.MonHoc_Insert
(

	@MaMonHoc nvarchar (4)  ,

	@TenMonHoc nvarchar (40)  ,

	@QuiDinhSoTietHocLienTiepToiThieu tinyint   ,

	@QuiDinhSoTietHocLienTiepToiDa tinyint   
)
AS


					
				INSERT INTO [dbo].[MonHoc]
					(
					[MaMonHoc]
					,[TenMonHoc]
					,[QuiDinhSoTietHocLienTiepToiThieu]
					,[QuiDinhSoTietHocLienTiepToiDa]
					)
				VALUES
					(
					@MaMonHoc
					,@TenMonHoc
					,@QuiDinhSoTietHocLienTiepToiThieu
					,@QuiDinhSoTietHocLienTiepToiDa
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

-- Created By:  ()
-- Purpose: Updates a record in the MonHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.MonHoc_Update
(

	@MaMonHoc nvarchar (4)  ,

	@OriginalMaMonHoc nvarchar (4)  ,

	@TenMonHoc nvarchar (40)  ,

	@QuiDinhSoTietHocLienTiepToiThieu tinyint   ,

	@QuiDinhSoTietHocLienTiepToiDa tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[MonHoc]
				SET
					[MaMonHoc] = @MaMonHoc
					,[TenMonHoc] = @TenMonHoc
					,[QuiDinhSoTietHocLienTiepToiThieu] = @QuiDinhSoTietHocLienTiepToiThieu
					,[QuiDinhSoTietHocLienTiepToiDa] = @QuiDinhSoTietHocLienTiepToiDa
				WHERE
[MaMonHoc] = @OriginalMaMonHoc 
				
			

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

-- Created By:  ()
-- Purpose: Deletes a record in the MonHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.MonHoc_Delete
(

	@MaMonHoc nvarchar (4)  
)
AS


				DELETE FROM [dbo].[MonHoc] WITH (ROWLOCK) 
				WHERE
					[MaMonHoc] = @MaMonHoc
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.MonHoc_GetByMaMonHoc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.MonHoc_GetByMaMonHoc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.MonHoc_GetByMaMonHoc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the MonHoc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.MonHoc_GetByMaMonHoc
(

	@MaMonHoc nvarchar (4)  
)
AS


				SELECT
					[MaMonHoc],
					[TenMonHoc],
					[QuiDinhSoTietHocLienTiepToiThieu],
					[QuiDinhSoTietHocLienTiepToiDa]
				FROM
					[dbo].[MonHoc]
				WHERE
					[MaMonHoc] = @MaMonHoc
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

-- Created By:  ()
-- Purpose: Finds records in the MonHoc table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.MonHoc_Find
(

	@SearchUsingOR bit   = null ,

	@MaMonHoc nvarchar (4)  = null ,

	@TenMonHoc nvarchar (40)  = null ,

	@QuiDinhSoTietHocLienTiepToiThieu tinyint   = null ,

	@QuiDinhSoTietHocLienTiepToiDa tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaMonHoc]
	, [TenMonHoc]
	, [QuiDinhSoTietHocLienTiepToiThieu]
	, [QuiDinhSoTietHocLienTiepToiDa]
    FROM
	[dbo].[MonHoc]
    WHERE 
	 ([MaMonHoc] = @MaMonHoc OR @MaMonHoc is null)
	AND ([TenMonHoc] = @TenMonHoc OR @TenMonHoc is null)
	AND ([QuiDinhSoTietHocLienTiepToiThieu] = @QuiDinhSoTietHocLienTiepToiThieu OR @QuiDinhSoTietHocLienTiepToiThieu is null)
	AND ([QuiDinhSoTietHocLienTiepToiDa] = @QuiDinhSoTietHocLienTiepToiDa OR @QuiDinhSoTietHocLienTiepToiDa is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaMonHoc]
	, [TenMonHoc]
	, [QuiDinhSoTietHocLienTiepToiThieu]
	, [QuiDinhSoTietHocLienTiepToiDa]
    FROM
	[dbo].[MonHoc]
    WHERE 
	 ([MaMonHoc] = @MaMonHoc AND @MaMonHoc is not null)
	OR ([TenMonHoc] = @TenMonHoc AND @TenMonHoc is not null)
	OR ([QuiDinhSoTietHocLienTiepToiThieu] = @QuiDinhSoTietHocLienTiepToiThieu AND @QuiDinhSoTietHocLienTiepToiThieu is not null)
	OR ([QuiDinhSoTietHocLienTiepToiDa] = @QuiDinhSoTietHocLienTiepToiDa AND @QuiDinhSoTietHocLienTiepToiDa is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ThoiKhoaBieu_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThoiKhoaBieu_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThoiKhoaBieu_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ThoiKhoaBieu table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThoiKhoaBieu_Get_List

AS


				
				SELECT
					[MaThoiKhoaBieu],
					[MaPhanCong],
					[MaLopHoc],
					[PhuTrach],
					[Thu],
					[TietHoc]
				FROM
					[dbo].[ThoiKhoaBieu]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ThoiKhoaBieu_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThoiKhoaBieu_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThoiKhoaBieu_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ThoiKhoaBieu table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThoiKhoaBieu_GetPaged
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
					SET @OrderBy = '[MaThoiKhoaBieu]'
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
				SET @SQL = @SQL + ', [MaThoiKhoaBieu]'
				SET @SQL = @SQL + ', [MaPhanCong]'
				SET @SQL = @SQL + ', [MaLopHoc]'
				SET @SQL = @SQL + ', [PhuTrach]'
				SET @SQL = @SQL + ', [Thu]'
				SET @SQL = @SQL + ', [TietHoc]'
				SET @SQL = @SQL + ' FROM [dbo].[ThoiKhoaBieu]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaThoiKhoaBieu],'
				SET @SQL = @SQL + ' [MaPhanCong],'
				SET @SQL = @SQL + ' [MaLopHoc],'
				SET @SQL = @SQL + ' [PhuTrach],'
				SET @SQL = @SQL + ' [Thu],'
				SET @SQL = @SQL + ' [TietHoc]'
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
				SET @SQL = @SQL + ' FROM [dbo].[ThoiKhoaBieu]'
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

	

-- Drop the dbo.ThoiKhoaBieu_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThoiKhoaBieu_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThoiKhoaBieu_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ThoiKhoaBieu table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThoiKhoaBieu_Insert
(

	@MaThoiKhoaBieu nvarchar (50)  ,

	@MaPhanCong nvarchar (50)  ,

	@MaLopHoc nvarchar (50)  ,

	@PhuTrach nvarchar (50)  ,

	@Thu int   ,

	@TietHoc int   
)
AS


					
				INSERT INTO [dbo].[ThoiKhoaBieu]
					(
					[MaThoiKhoaBieu]
					,[MaPhanCong]
					,[MaLopHoc]
					,[PhuTrach]
					,[Thu]
					,[TietHoc]
					)
				VALUES
					(
					@MaThoiKhoaBieu
					,@MaPhanCong
					,@MaLopHoc
					,@PhuTrach
					,@Thu
					,@TietHoc
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ThoiKhoaBieu_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThoiKhoaBieu_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThoiKhoaBieu_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ThoiKhoaBieu table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThoiKhoaBieu_Update
(

	@MaThoiKhoaBieu nvarchar (50)  ,

	@OriginalMaThoiKhoaBieu nvarchar (50)  ,

	@MaPhanCong nvarchar (50)  ,

	@MaLopHoc nvarchar (50)  ,

	@PhuTrach nvarchar (50)  ,

	@Thu int   ,

	@TietHoc int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ThoiKhoaBieu]
				SET
					[MaThoiKhoaBieu] = @MaThoiKhoaBieu
					,[MaPhanCong] = @MaPhanCong
					,[MaLopHoc] = @MaLopHoc
					,[PhuTrach] = @PhuTrach
					,[Thu] = @Thu
					,[TietHoc] = @TietHoc
				WHERE
[MaThoiKhoaBieu] = @OriginalMaThoiKhoaBieu 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ThoiKhoaBieu_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThoiKhoaBieu_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThoiKhoaBieu_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ThoiKhoaBieu table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThoiKhoaBieu_Delete
(

	@MaThoiKhoaBieu nvarchar (50)  
)
AS


				DELETE FROM [dbo].[ThoiKhoaBieu] WITH (ROWLOCK) 
				WHERE
					[MaThoiKhoaBieu] = @MaThoiKhoaBieu
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ThoiKhoaBieu_GetByMaThoiKhoaBieu procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThoiKhoaBieu_GetByMaThoiKhoaBieu') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThoiKhoaBieu_GetByMaThoiKhoaBieu
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ThoiKhoaBieu table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThoiKhoaBieu_GetByMaThoiKhoaBieu
(

	@MaThoiKhoaBieu nvarchar (50)  
)
AS


				SELECT
					[MaThoiKhoaBieu],
					[MaPhanCong],
					[MaLopHoc],
					[PhuTrach],
					[Thu],
					[TietHoc]
				FROM
					[dbo].[ThoiKhoaBieu]
				WHERE
					[MaThoiKhoaBieu] = @MaThoiKhoaBieu
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ThoiKhoaBieu_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThoiKhoaBieu_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThoiKhoaBieu_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ThoiKhoaBieu table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThoiKhoaBieu_Find
(

	@SearchUsingOR bit   = null ,

	@MaThoiKhoaBieu nvarchar (50)  = null ,

	@MaPhanCong nvarchar (50)  = null ,

	@MaLopHoc nvarchar (50)  = null ,

	@PhuTrach nvarchar (50)  = null ,

	@Thu int   = null ,

	@TietHoc int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaThoiKhoaBieu]
	, [MaPhanCong]
	, [MaLopHoc]
	, [PhuTrach]
	, [Thu]
	, [TietHoc]
    FROM
	[dbo].[ThoiKhoaBieu]
    WHERE 
	 ([MaThoiKhoaBieu] = @MaThoiKhoaBieu OR @MaThoiKhoaBieu is null)
	AND ([MaPhanCong] = @MaPhanCong OR @MaPhanCong is null)
	AND ([MaLopHoc] = @MaLopHoc OR @MaLopHoc is null)
	AND ([PhuTrach] = @PhuTrach OR @PhuTrach is null)
	AND ([Thu] = @Thu OR @Thu is null)
	AND ([TietHoc] = @TietHoc OR @TietHoc is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaThoiKhoaBieu]
	, [MaPhanCong]
	, [MaLopHoc]
	, [PhuTrach]
	, [Thu]
	, [TietHoc]
    FROM
	[dbo].[ThoiKhoaBieu]
    WHERE 
	 ([MaThoiKhoaBieu] = @MaThoiKhoaBieu AND @MaThoiKhoaBieu is not null)
	OR ([MaPhanCong] = @MaPhanCong AND @MaPhanCong is not null)
	OR ([MaLopHoc] = @MaLopHoc AND @MaLopHoc is not null)
	OR ([PhuTrach] = @PhuTrach AND @PhuTrach is not null)
	OR ([Thu] = @Thu AND @Thu is not null)
	OR ([TietHoc] = @TietHoc AND @TietHoc is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ThamSo_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThamSo_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThamSo_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ThamSo table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThamSo_Get_List

AS


				
				SELECT
					[SoTietToiDaTrongNgay],
					[TietGay],
					[SoTietToiDaDuocHocTrongNgay]
				FROM
					[dbo].[ThamSo]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ThamSo_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThamSo_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThamSo_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ThamSo table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThamSo_GetPaged
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
					SET @OrderBy = '[SoTietToiDaTrongNgay]'
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
				SET @SQL = @SQL + ', [SoTietToiDaTrongNgay]'
				SET @SQL = @SQL + ', [TietGay]'
				SET @SQL = @SQL + ', [SoTietToiDaDuocHocTrongNgay]'
				SET @SQL = @SQL + ' FROM [dbo].[ThamSo]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SoTietToiDaTrongNgay],'
				SET @SQL = @SQL + ' [TietGay],'
				SET @SQL = @SQL + ' [SoTietToiDaDuocHocTrongNgay]'
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
				SET @SQL = @SQL + ' FROM [dbo].[ThamSo]'
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

	

-- Drop the dbo.ThamSo_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThamSo_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThamSo_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ThamSo table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThamSo_Insert
(

	@SoTietToiDaTrongNgay tinyint   ,

	@TietGay tinyint   ,

	@SoTietToiDaDuocHocTrongNgay smallint   
)
AS


					
				INSERT INTO [dbo].[ThamSo]
					(
					[SoTietToiDaTrongNgay]
					,[TietGay]
					,[SoTietToiDaDuocHocTrongNgay]
					)
				VALUES
					(
					@SoTietToiDaTrongNgay
					,@TietGay
					,@SoTietToiDaDuocHocTrongNgay
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ThamSo_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThamSo_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThamSo_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ThamSo table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThamSo_Update
(

	@SoTietToiDaTrongNgay tinyint   ,

	@OriginalSoTietToiDaTrongNgay tinyint   ,

	@TietGay tinyint   ,

	@OriginalTietGay tinyint   ,

	@SoTietToiDaDuocHocTrongNgay smallint   ,

	@OriginalSoTietToiDaDuocHocTrongNgay smallint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ThamSo]
				SET
					[SoTietToiDaTrongNgay] = @SoTietToiDaTrongNgay
					,[TietGay] = @TietGay
					,[SoTietToiDaDuocHocTrongNgay] = @SoTietToiDaDuocHocTrongNgay
				WHERE
[SoTietToiDaTrongNgay] = @OriginalSoTietToiDaTrongNgay 
AND [TietGay] = @OriginalTietGay 
AND [SoTietToiDaDuocHocTrongNgay] = @OriginalSoTietToiDaDuocHocTrongNgay 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ThamSo_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThamSo_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThamSo_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ThamSo table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThamSo_Delete
(

	@SoTietToiDaTrongNgay tinyint   ,

	@TietGay tinyint   ,

	@SoTietToiDaDuocHocTrongNgay smallint   
)
AS


				DELETE FROM [dbo].[ThamSo] WITH (ROWLOCK) 
				WHERE
					[SoTietToiDaTrongNgay] = @SoTietToiDaTrongNgay
					AND [TietGay] = @TietGay
					AND [SoTietToiDaDuocHocTrongNgay] = @SoTietToiDaDuocHocTrongNgay
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ThamSo_GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThamSo_GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThamSo_GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ThamSo table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThamSo_GetBySoTietToiDaTrongNgayTietGaySoTietToiDaDuocHocTrongNgay
(

	@SoTietToiDaTrongNgay tinyint   ,

	@TietGay tinyint   ,

	@SoTietToiDaDuocHocTrongNgay smallint   
)
AS


				SELECT
					[SoTietToiDaTrongNgay],
					[TietGay],
					[SoTietToiDaDuocHocTrongNgay]
				FROM
					[dbo].[ThamSo]
				WHERE
					[SoTietToiDaTrongNgay] = @SoTietToiDaTrongNgay
					AND [TietGay] = @TietGay
					AND [SoTietToiDaDuocHocTrongNgay] = @SoTietToiDaDuocHocTrongNgay
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ThamSo_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ThamSo_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ThamSo_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ThamSo table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ThamSo_Find
(

	@SearchUsingOR bit   = null ,

	@SoTietToiDaTrongNgay tinyint   = null ,

	@TietGay tinyint   = null ,

	@SoTietToiDaDuocHocTrongNgay smallint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SoTietToiDaTrongNgay]
	, [TietGay]
	, [SoTietToiDaDuocHocTrongNgay]
    FROM
	[dbo].[ThamSo]
    WHERE 
	 ([SoTietToiDaTrongNgay] = @SoTietToiDaTrongNgay OR @SoTietToiDaTrongNgay is null)
	AND ([TietGay] = @TietGay OR @TietGay is null)
	AND ([SoTietToiDaDuocHocTrongNgay] = @SoTietToiDaDuocHocTrongNgay OR @SoTietToiDaDuocHocTrongNgay is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SoTietToiDaTrongNgay]
	, [TietGay]
	, [SoTietToiDaDuocHocTrongNgay]
    FROM
	[dbo].[ThamSo]
    WHERE 
	 ([SoTietToiDaTrongNgay] = @SoTietToiDaTrongNgay AND @SoTietToiDaTrongNgay is not null)
	OR ([TietGay] = @TietGay AND @TietGay is not null)
	OR ([SoTietToiDaDuocHocTrongNgay] = @SoTietToiDaDuocHocTrongNgay AND @SoTietToiDaDuocHocTrongNgay is not null)
	Select @@ROWCOUNT			
  END
				

GO
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

-- Created By:  ()
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

-- Created By:  ()
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

-- Created By:  ()
-- Purpose: Inserts a record into the Khoi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Khoi_Insert
(

	@MaKhoi nvarchar (3)  ,

	@TenKhoi nvarchar (10)  
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

-- Created By:  ()
-- Purpose: Updates a record in the Khoi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Khoi_Update
(

	@MaKhoi nvarchar (3)  ,

	@OriginalMaKhoi nvarchar (3)  ,

	@TenKhoi nvarchar (10)  
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

-- Created By:  ()
-- Purpose: Deletes a record in the Khoi table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Khoi_Delete
(

	@MaKhoi nvarchar (3)  
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

-- Created By:  ()
-- Purpose: Select records from the Khoi table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Khoi_GetByMaKhoi
(

	@MaKhoi nvarchar (3)  
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

-- Created By:  ()
-- Purpose: Finds records in the Khoi table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Khoi_Find
(

	@SearchUsingOR bit   = null ,

	@MaKhoi nvarchar (3)  = null ,

	@TenKhoi nvarchar (10)  = null 
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

	

-- Drop the dbo.GiaoVien_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.GiaoVien_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.GiaoVien_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the GiaoVien table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.GiaoVien_Get_List

AS


				
				SELECT
					[MaGiaoVien],
					[HoTenGiaoVien],
					[TenTat],
					[DiaChi],
					[DienThoai]
				FROM
					[dbo].[GiaoVien]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.GiaoVien_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.GiaoVien_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.GiaoVien_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the GiaoVien table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.GiaoVien_GetPaged
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
					SET @OrderBy = '[MaGiaoVien]'
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
				SET @SQL = @SQL + ', [MaGiaoVien]'
				SET @SQL = @SQL + ', [HoTenGiaoVien]'
				SET @SQL = @SQL + ', [TenTat]'
				SET @SQL = @SQL + ', [DiaChi]'
				SET @SQL = @SQL + ', [DienThoai]'
				SET @SQL = @SQL + ' FROM [dbo].[GiaoVien]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaGiaoVien],'
				SET @SQL = @SQL + ' [HoTenGiaoVien],'
				SET @SQL = @SQL + ' [TenTat],'
				SET @SQL = @SQL + ' [DiaChi],'
				SET @SQL = @SQL + ' [DienThoai]'
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
				SET @SQL = @SQL + ' FROM [dbo].[GiaoVien]'
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

	

-- Drop the dbo.GiaoVien_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.GiaoVien_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.GiaoVien_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the GiaoVien table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.GiaoVien_Insert
(

	@MaGiaoVien nvarchar (5)  ,

	@HoTenGiaoVien nvarchar (30)  ,

	@TenTat nvarchar (15)  ,

	@DiaChi nvarchar (100)  ,

	@DienThoai nvarchar (21)  
)
AS


					
				INSERT INTO [dbo].[GiaoVien]
					(
					[MaGiaoVien]
					,[HoTenGiaoVien]
					,[TenTat]
					,[DiaChi]
					,[DienThoai]
					)
				VALUES
					(
					@MaGiaoVien
					,@HoTenGiaoVien
					,@TenTat
					,@DiaChi
					,@DienThoai
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.GiaoVien_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.GiaoVien_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.GiaoVien_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the GiaoVien table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.GiaoVien_Update
(

	@MaGiaoVien nvarchar (5)  ,

	@OriginalMaGiaoVien nvarchar (5)  ,

	@HoTenGiaoVien nvarchar (30)  ,

	@TenTat nvarchar (15)  ,

	@DiaChi nvarchar (100)  ,

	@DienThoai nvarchar (21)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[GiaoVien]
				SET
					[MaGiaoVien] = @MaGiaoVien
					,[HoTenGiaoVien] = @HoTenGiaoVien
					,[TenTat] = @TenTat
					,[DiaChi] = @DiaChi
					,[DienThoai] = @DienThoai
				WHERE
[MaGiaoVien] = @OriginalMaGiaoVien 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.GiaoVien_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.GiaoVien_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.GiaoVien_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the GiaoVien table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.GiaoVien_Delete
(

	@MaGiaoVien nvarchar (5)  
)
AS


				DELETE FROM [dbo].[GiaoVien] WITH (ROWLOCK) 
				WHERE
					[MaGiaoVien] = @MaGiaoVien
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.GiaoVien_GetByMaGiaoVien procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.GiaoVien_GetByMaGiaoVien') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.GiaoVien_GetByMaGiaoVien
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the GiaoVien table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.GiaoVien_GetByMaGiaoVien
(

	@MaGiaoVien nvarchar (5)  
)
AS


				SELECT
					[MaGiaoVien],
					[HoTenGiaoVien],
					[TenTat],
					[DiaChi],
					[DienThoai]
				FROM
					[dbo].[GiaoVien]
				WHERE
					[MaGiaoVien] = @MaGiaoVien
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.GiaoVien_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.GiaoVien_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.GiaoVien_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the GiaoVien table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.GiaoVien_Find
(

	@SearchUsingOR bit   = null ,

	@MaGiaoVien nvarchar (5)  = null ,

	@HoTenGiaoVien nvarchar (30)  = null ,

	@TenTat nvarchar (15)  = null ,

	@DiaChi nvarchar (100)  = null ,

	@DienThoai nvarchar (21)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaGiaoVien]
	, [HoTenGiaoVien]
	, [TenTat]
	, [DiaChi]
	, [DienThoai]
    FROM
	[dbo].[GiaoVien]
    WHERE 
	 ([MaGiaoVien] = @MaGiaoVien OR @MaGiaoVien is null)
	AND ([HoTenGiaoVien] = @HoTenGiaoVien OR @HoTenGiaoVien is null)
	AND ([TenTat] = @TenTat OR @TenTat is null)
	AND ([DiaChi] = @DiaChi OR @DiaChi is null)
	AND ([DienThoai] = @DienThoai OR @DienThoai is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaGiaoVien]
	, [HoTenGiaoVien]
	, [TenTat]
	, [DiaChi]
	, [DienThoai]
    FROM
	[dbo].[GiaoVien]
    WHERE 
	 ([MaGiaoVien] = @MaGiaoVien AND @MaGiaoVien is not null)
	OR ([HoTenGiaoVien] = @HoTenGiaoVien AND @HoTenGiaoVien is not null)
	OR ([TenTat] = @TenTat AND @TenTat is not null)
	OR ([DiaChi] = @DiaChi AND @DiaChi is not null)
	OR ([DienThoai] = @DienThoai AND @DienThoai is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocGiaoVien_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocGiaoVien_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocGiaoVien_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the RangBuocGiaoVien table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocGiaoVien_Get_List

AS


				
				SELECT
					[MaRangBuocGiaoVien],
					[MaGiaoVien],
					[Thu],
					[TietHoc],
					[TrangThai]
				FROM
					[dbo].[RangBuocGiaoVien]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocGiaoVien_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocGiaoVien_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocGiaoVien_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the RangBuocGiaoVien table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocGiaoVien_GetPaged
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
					SET @OrderBy = '[MaRangBuocGiaoVien]'
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
				SET @SQL = @SQL + ', [MaRangBuocGiaoVien]'
				SET @SQL = @SQL + ', [MaGiaoVien]'
				SET @SQL = @SQL + ', [Thu]'
				SET @SQL = @SQL + ', [TietHoc]'
				SET @SQL = @SQL + ', [TrangThai]'
				SET @SQL = @SQL + ' FROM [dbo].[RangBuocGiaoVien]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaRangBuocGiaoVien],'
				SET @SQL = @SQL + ' [MaGiaoVien],'
				SET @SQL = @SQL + ' [Thu],'
				SET @SQL = @SQL + ' [TietHoc],'
				SET @SQL = @SQL + ' [TrangThai]'
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
				SET @SQL = @SQL + ' FROM [dbo].[RangBuocGiaoVien]'
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

	

-- Drop the dbo.RangBuocGiaoVien_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocGiaoVien_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocGiaoVien_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the RangBuocGiaoVien table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocGiaoVien_Insert
(

	@MaRangBuocGiaoVien nvarchar (9)  ,

	@MaGiaoVien nvarchar (5)  ,

	@Thu tinyint   ,

	@TietHoc tinyint   ,

	@TrangThai tinyint   
)
AS


					
				INSERT INTO [dbo].[RangBuocGiaoVien]
					(
					[MaRangBuocGiaoVien]
					,[MaGiaoVien]
					,[Thu]
					,[TietHoc]
					,[TrangThai]
					)
				VALUES
					(
					@MaRangBuocGiaoVien
					,@MaGiaoVien
					,@Thu
					,@TietHoc
					,@TrangThai
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocGiaoVien_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocGiaoVien_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocGiaoVien_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the RangBuocGiaoVien table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocGiaoVien_Update
(

	@MaRangBuocGiaoVien nvarchar (9)  ,

	@OriginalMaRangBuocGiaoVien nvarchar (9)  ,

	@MaGiaoVien nvarchar (5)  ,

	@Thu tinyint   ,

	@TietHoc tinyint   ,

	@TrangThai tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[RangBuocGiaoVien]
				SET
					[MaRangBuocGiaoVien] = @MaRangBuocGiaoVien
					,[MaGiaoVien] = @MaGiaoVien
					,[Thu] = @Thu
					,[TietHoc] = @TietHoc
					,[TrangThai] = @TrangThai
				WHERE
[MaRangBuocGiaoVien] = @OriginalMaRangBuocGiaoVien 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocGiaoVien_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocGiaoVien_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocGiaoVien_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the RangBuocGiaoVien table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocGiaoVien_Delete
(

	@MaRangBuocGiaoVien nvarchar (9)  
)
AS


				DELETE FROM [dbo].[RangBuocGiaoVien] WITH (ROWLOCK) 
				WHERE
					[MaRangBuocGiaoVien] = @MaRangBuocGiaoVien
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocGiaoVien_GetByMaRangBuocGiaoVien procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocGiaoVien_GetByMaRangBuocGiaoVien') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocGiaoVien_GetByMaRangBuocGiaoVien
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the RangBuocGiaoVien table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocGiaoVien_GetByMaRangBuocGiaoVien
(

	@MaRangBuocGiaoVien nvarchar (9)  
)
AS


				SELECT
					[MaRangBuocGiaoVien],
					[MaGiaoVien],
					[Thu],
					[TietHoc],
					[TrangThai]
				FROM
					[dbo].[RangBuocGiaoVien]
				WHERE
					[MaRangBuocGiaoVien] = @MaRangBuocGiaoVien
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocGiaoVien_GetByMaGiaoVien procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocGiaoVien_GetByMaGiaoVien') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocGiaoVien_GetByMaGiaoVien
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the RangBuocGiaoVien table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocGiaoVien_GetByMaGiaoVien
(

	@MaGiaoVien nvarchar (5)  
)
AS


				SELECT
					[MaRangBuocGiaoVien],
					[MaGiaoVien],
					[Thu],
					[TietHoc],
					[TrangThai]
				FROM
					[dbo].[RangBuocGiaoVien]
				WHERE
					[MaGiaoVien] = @MaGiaoVien
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RangBuocGiaoVien_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RangBuocGiaoVien_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RangBuocGiaoVien_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the RangBuocGiaoVien table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RangBuocGiaoVien_Find
(

	@SearchUsingOR bit   = null ,

	@MaRangBuocGiaoVien nvarchar (9)  = null ,

	@MaGiaoVien nvarchar (5)  = null ,

	@Thu tinyint   = null ,

	@TietHoc tinyint   = null ,

	@TrangThai tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaRangBuocGiaoVien]
	, [MaGiaoVien]
	, [Thu]
	, [TietHoc]
	, [TrangThai]
    FROM
	[dbo].[RangBuocGiaoVien]
    WHERE 
	 ([MaRangBuocGiaoVien] = @MaRangBuocGiaoVien OR @MaRangBuocGiaoVien is null)
	AND ([MaGiaoVien] = @MaGiaoVien OR @MaGiaoVien is null)
	AND ([Thu] = @Thu OR @Thu is null)
	AND ([TietHoc] = @TietHoc OR @TietHoc is null)
	AND ([TrangThai] = @TrangThai OR @TrangThai is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaRangBuocGiaoVien]
	, [MaGiaoVien]
	, [Thu]
	, [TietHoc]
	, [TrangThai]
    FROM
	[dbo].[RangBuocGiaoVien]
    WHERE 
	 ([MaRangBuocGiaoVien] = @MaRangBuocGiaoVien AND @MaRangBuocGiaoVien is not null)
	OR ([MaGiaoVien] = @MaGiaoVien AND @MaGiaoVien is not null)
	OR ([Thu] = @Thu AND @Thu is not null)
	OR ([TietHoc] = @TietHoc AND @TietHoc is not null)
	OR ([TrangThai] = @TrangThai AND @TrangThai is not null)
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

-- Created By:  ()
-- Purpose: Gets all records from the LopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_Get_List

AS


				
				SELECT
					[MaLopHoc],
					[TenLopHoc],
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

-- Created By:  ()
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
					SET @OrderBy = '[MaLopHoc]'
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
				SET @SQL = @SQL + ', [MaLopHoc]'
				SET @SQL = @SQL + ', [TenLopHoc]'
				SET @SQL = @SQL + ', [MaKhoi]'
				SET @SQL = @SQL + ' FROM [dbo].[LopHoc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaLopHoc],'
				SET @SQL = @SQL + ' [TenLopHoc],'
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

-- Created By:  ()
-- Purpose: Inserts a record into the LopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_Insert
(

	@MaLopHoc nvarchar (4)  ,

	@TenLopHoc nvarchar (20)  ,

	@MaKhoi nvarchar (3)  
)
AS


					
				INSERT INTO [dbo].[LopHoc]
					(
					[MaLopHoc]
					,[TenLopHoc]
					,[MaKhoi]
					)
				VALUES
					(
					@MaLopHoc
					,@TenLopHoc
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

-- Created By:  ()
-- Purpose: Updates a record in the LopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_Update
(

	@MaLopHoc nvarchar (4)  ,

	@OriginalMaLopHoc nvarchar (4)  ,

	@TenLopHoc nvarchar (20)  ,

	@MaKhoi nvarchar (3)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[LopHoc]
				SET
					[MaLopHoc] = @MaLopHoc
					,[TenLopHoc] = @TenLopHoc
					,[MaKhoi] = @MaKhoi
				WHERE
[MaLopHoc] = @OriginalMaLopHoc 
				
			

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

-- Created By:  ()
-- Purpose: Deletes a record in the LopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_Delete
(

	@MaLopHoc nvarchar (4)  
)
AS


				DELETE FROM [dbo].[LopHoc] WITH (ROWLOCK) 
				WHERE
					[MaLopHoc] = @MaLopHoc
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LopHoc_GetByMaLopHoc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LopHoc_GetByMaLopHoc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LopHoc_GetByMaLopHoc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LopHoc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_GetByMaLopHoc
(

	@MaLopHoc nvarchar (4)  
)
AS


				SELECT
					[MaLopHoc],
					[TenLopHoc],
					[MaKhoi]
				FROM
					[dbo].[LopHoc]
				WHERE
					[MaLopHoc] = @MaLopHoc
			Select @@ROWCOUNT
					
			

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

-- Created By:  ()
-- Purpose: Select records from the LopHoc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_GetByMaKhoi
(

	@MaKhoi nvarchar (3)  
)
AS


				SELECT
					[MaLopHoc],
					[TenLopHoc],
					[MaKhoi]
				FROM
					[dbo].[LopHoc]
				WHERE
					[MaKhoi] = @MaKhoi
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

-- Created By:  ()
-- Purpose: Finds records in the LopHoc table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LopHoc_Find
(

	@SearchUsingOR bit   = null ,

	@MaLopHoc nvarchar (4)  = null ,

	@TenLopHoc nvarchar (20)  = null ,

	@MaKhoi nvarchar (3)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaLopHoc]
	, [TenLopHoc]
	, [MaKhoi]
    FROM
	[dbo].[LopHoc]
    WHERE 
	 ([MaLopHoc] = @MaLopHoc OR @MaLopHoc is null)
	AND ([TenLopHoc] = @TenLopHoc OR @TenLopHoc is null)
	AND ([MaKhoi] = @MaKhoi OR @MaKhoi is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaLopHoc]
	, [TenLopHoc]
	, [MaKhoi]
    FROM
	[dbo].[LopHoc]
    WHERE 
	 ([MaLopHoc] = @MaLopHoc AND @MaLopHoc is not null)
	OR ([TenLopHoc] = @TenLopHoc AND @TenLopHoc is not null)
	OR ([MaKhoi] = @MaKhoi AND @MaKhoi is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhanCong_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhanCong_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhanCong_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the PhanCong table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhanCong_Get_List

AS


				
				SELECT
					[MaPhanCong],
					[MaLopHoc],
					[MaMonHoc],
					[MaGiaoVien],
					[SoTietHocTuan],
					[SoTietHocLienTiepToiThieu],
					[SoTietHocLienTiepToiDa],
					[SoBuoiHocToiThieu],
					[SoBuoiHocToiDa]
				FROM
					[dbo].[PhanCong]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhanCong_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhanCong_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhanCong_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the PhanCong table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhanCong_GetPaged
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
					SET @OrderBy = '[MaPhanCong]'
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
				SET @SQL = @SQL + ', [MaPhanCong]'
				SET @SQL = @SQL + ', [MaLopHoc]'
				SET @SQL = @SQL + ', [MaMonHoc]'
				SET @SQL = @SQL + ', [MaGiaoVien]'
				SET @SQL = @SQL + ', [SoTietHocTuan]'
				SET @SQL = @SQL + ', [SoTietHocLienTiepToiThieu]'
				SET @SQL = @SQL + ', [SoTietHocLienTiepToiDa]'
				SET @SQL = @SQL + ', [SoBuoiHocToiThieu]'
				SET @SQL = @SQL + ', [SoBuoiHocToiDa]'
				SET @SQL = @SQL + ' FROM [dbo].[PhanCong]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaPhanCong],'
				SET @SQL = @SQL + ' [MaLopHoc],'
				SET @SQL = @SQL + ' [MaMonHoc],'
				SET @SQL = @SQL + ' [MaGiaoVien],'
				SET @SQL = @SQL + ' [SoTietHocTuan],'
				SET @SQL = @SQL + ' [SoTietHocLienTiepToiThieu],'
				SET @SQL = @SQL + ' [SoTietHocLienTiepToiDa],'
				SET @SQL = @SQL + ' [SoBuoiHocToiThieu],'
				SET @SQL = @SQL + ' [SoBuoiHocToiDa]'
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
				SET @SQL = @SQL + ' FROM [dbo].[PhanCong]'
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

	

-- Drop the dbo.PhanCong_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhanCong_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhanCong_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the PhanCong table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhanCong_Insert
(

	@MaPhanCong nvarchar (6)  ,

	@MaLopHoc nvarchar (4)  ,

	@MaMonHoc nvarchar (4)  ,

	@MaGiaoVien nvarchar (5)  ,

	@SoTietHocTuan tinyint   ,

	@SoTietHocLienTiepToiThieu tinyint   ,

	@SoTietHocLienTiepToiDa tinyint   ,

	@SoBuoiHocToiThieu tinyint   ,

	@SoBuoiHocToiDa tinyint   
)
AS


					
				INSERT INTO [dbo].[PhanCong]
					(
					[MaPhanCong]
					,[MaLopHoc]
					,[MaMonHoc]
					,[MaGiaoVien]
					,[SoTietHocTuan]
					,[SoTietHocLienTiepToiThieu]
					,[SoTietHocLienTiepToiDa]
					,[SoBuoiHocToiThieu]
					,[SoBuoiHocToiDa]
					)
				VALUES
					(
					@MaPhanCong
					,@MaLopHoc
					,@MaMonHoc
					,@MaGiaoVien
					,@SoTietHocTuan
					,@SoTietHocLienTiepToiThieu
					,@SoTietHocLienTiepToiDa
					,@SoBuoiHocToiThieu
					,@SoBuoiHocToiDa
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhanCong_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhanCong_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhanCong_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the PhanCong table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhanCong_Update
(

	@MaPhanCong nvarchar (6)  ,

	@OriginalMaPhanCong nvarchar (6)  ,

	@MaLopHoc nvarchar (4)  ,

	@MaMonHoc nvarchar (4)  ,

	@MaGiaoVien nvarchar (5)  ,

	@SoTietHocTuan tinyint   ,

	@SoTietHocLienTiepToiThieu tinyint   ,

	@SoTietHocLienTiepToiDa tinyint   ,

	@SoBuoiHocToiThieu tinyint   ,

	@SoBuoiHocToiDa tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[PhanCong]
				SET
					[MaPhanCong] = @MaPhanCong
					,[MaLopHoc] = @MaLopHoc
					,[MaMonHoc] = @MaMonHoc
					,[MaGiaoVien] = @MaGiaoVien
					,[SoTietHocTuan] = @SoTietHocTuan
					,[SoTietHocLienTiepToiThieu] = @SoTietHocLienTiepToiThieu
					,[SoTietHocLienTiepToiDa] = @SoTietHocLienTiepToiDa
					,[SoBuoiHocToiThieu] = @SoBuoiHocToiThieu
					,[SoBuoiHocToiDa] = @SoBuoiHocToiDa
				WHERE
[MaPhanCong] = @OriginalMaPhanCong 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhanCong_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhanCong_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhanCong_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the PhanCong table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhanCong_Delete
(

	@MaPhanCong nvarchar (6)  
)
AS


				DELETE FROM [dbo].[PhanCong] WITH (ROWLOCK) 
				WHERE
					[MaPhanCong] = @MaPhanCong
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhanCong_GetByMaPhanCong procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhanCong_GetByMaPhanCong') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhanCong_GetByMaPhanCong
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the PhanCong table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhanCong_GetByMaPhanCong
(

	@MaPhanCong nvarchar (6)  
)
AS


				SELECT
					[MaPhanCong],
					[MaLopHoc],
					[MaMonHoc],
					[MaGiaoVien],
					[SoTietHocTuan],
					[SoTietHocLienTiepToiThieu],
					[SoTietHocLienTiepToiDa],
					[SoBuoiHocToiThieu],
					[SoBuoiHocToiDa]
				FROM
					[dbo].[PhanCong]
				WHERE
					[MaPhanCong] = @MaPhanCong
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhanCong_GetByMaGiaoVien procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhanCong_GetByMaGiaoVien') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhanCong_GetByMaGiaoVien
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the PhanCong table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhanCong_GetByMaGiaoVien
(

	@MaGiaoVien nvarchar (5)  
)
AS


				SELECT
					[MaPhanCong],
					[MaLopHoc],
					[MaMonHoc],
					[MaGiaoVien],
					[SoTietHocTuan],
					[SoTietHocLienTiepToiThieu],
					[SoTietHocLienTiepToiDa],
					[SoBuoiHocToiThieu],
					[SoBuoiHocToiDa]
				FROM
					[dbo].[PhanCong]
				WHERE
					[MaGiaoVien] = @MaGiaoVien
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhanCong_GetByMaLopHoc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhanCong_GetByMaLopHoc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhanCong_GetByMaLopHoc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the PhanCong table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhanCong_GetByMaLopHoc
(

	@MaLopHoc nvarchar (4)  
)
AS


				SELECT
					[MaPhanCong],
					[MaLopHoc],
					[MaMonHoc],
					[MaGiaoVien],
					[SoTietHocTuan],
					[SoTietHocLienTiepToiThieu],
					[SoTietHocLienTiepToiDa],
					[SoBuoiHocToiThieu],
					[SoBuoiHocToiDa]
				FROM
					[dbo].[PhanCong]
				WHERE
					[MaLopHoc] = @MaLopHoc
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhanCong_GetByMaMonHoc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhanCong_GetByMaMonHoc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhanCong_GetByMaMonHoc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the PhanCong table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhanCong_GetByMaMonHoc
(

	@MaMonHoc nvarchar (4)  
)
AS


				SELECT
					[MaPhanCong],
					[MaLopHoc],
					[MaMonHoc],
					[MaGiaoVien],
					[SoTietHocTuan],
					[SoTietHocLienTiepToiThieu],
					[SoTietHocLienTiepToiDa],
					[SoBuoiHocToiThieu],
					[SoBuoiHocToiDa]
				FROM
					[dbo].[PhanCong]
				WHERE
					[MaMonHoc] = @MaMonHoc
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhanCong_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhanCong_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhanCong_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the PhanCong table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhanCong_Find
(

	@SearchUsingOR bit   = null ,

	@MaPhanCong nvarchar (6)  = null ,

	@MaLopHoc nvarchar (4)  = null ,

	@MaMonHoc nvarchar (4)  = null ,

	@MaGiaoVien nvarchar (5)  = null ,

	@SoTietHocTuan tinyint   = null ,

	@SoTietHocLienTiepToiThieu tinyint   = null ,

	@SoTietHocLienTiepToiDa tinyint   = null ,

	@SoBuoiHocToiThieu tinyint   = null ,

	@SoBuoiHocToiDa tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaPhanCong]
	, [MaLopHoc]
	, [MaMonHoc]
	, [MaGiaoVien]
	, [SoTietHocTuan]
	, [SoTietHocLienTiepToiThieu]
	, [SoTietHocLienTiepToiDa]
	, [SoBuoiHocToiThieu]
	, [SoBuoiHocToiDa]
    FROM
	[dbo].[PhanCong]
    WHERE 
	 ([MaPhanCong] = @MaPhanCong OR @MaPhanCong is null)
	AND ([MaLopHoc] = @MaLopHoc OR @MaLopHoc is null)
	AND ([MaMonHoc] = @MaMonHoc OR @MaMonHoc is null)
	AND ([MaGiaoVien] = @MaGiaoVien OR @MaGiaoVien is null)
	AND ([SoTietHocTuan] = @SoTietHocTuan OR @SoTietHocTuan is null)
	AND ([SoTietHocLienTiepToiThieu] = @SoTietHocLienTiepToiThieu OR @SoTietHocLienTiepToiThieu is null)
	AND ([SoTietHocLienTiepToiDa] = @SoTietHocLienTiepToiDa OR @SoTietHocLienTiepToiDa is null)
	AND ([SoBuoiHocToiThieu] = @SoBuoiHocToiThieu OR @SoBuoiHocToiThieu is null)
	AND ([SoBuoiHocToiDa] = @SoBuoiHocToiDa OR @SoBuoiHocToiDa is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaPhanCong]
	, [MaLopHoc]
	, [MaMonHoc]
	, [MaGiaoVien]
	, [SoTietHocTuan]
	, [SoTietHocLienTiepToiThieu]
	, [SoTietHocLienTiepToiDa]
	, [SoBuoiHocToiThieu]
	, [SoBuoiHocToiDa]
    FROM
	[dbo].[PhanCong]
    WHERE 
	 ([MaPhanCong] = @MaPhanCong AND @MaPhanCong is not null)
	OR ([MaLopHoc] = @MaLopHoc AND @MaLopHoc is not null)
	OR ([MaMonHoc] = @MaMonHoc AND @MaMonHoc is not null)
	OR ([MaGiaoVien] = @MaGiaoVien AND @MaGiaoVien is not null)
	OR ([SoTietHocTuan] = @SoTietHocTuan AND @SoTietHocTuan is not null)
	OR ([SoTietHocLienTiepToiThieu] = @SoTietHocLienTiepToiThieu AND @SoTietHocLienTiepToiThieu is not null)
	OR ([SoTietHocLienTiepToiDa] = @SoTietHocLienTiepToiDa AND @SoTietHocLienTiepToiDa is not null)
	OR ([SoBuoiHocToiThieu] = @SoBuoiHocToiThieu AND @SoBuoiHocToiThieu is not null)
	OR ([SoBuoiHocToiDa] = @SoBuoiHocToiDa AND @SoBuoiHocToiDa is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhuTrach_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhuTrach_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhuTrach_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the PhuTrach table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhuTrach_Get_List

AS


				
				SELECT
					[MaPhuTrach],
					[MaGiaoVien],
					[MaMonHoc]
				FROM
					[dbo].[PhuTrach]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhuTrach_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhuTrach_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhuTrach_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the PhuTrach table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhuTrach_GetPaged
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
					SET @OrderBy = '[MaPhuTrach]'
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
				SET @SQL = @SQL + ', [MaPhuTrach]'
				SET @SQL = @SQL + ', [MaGiaoVien]'
				SET @SQL = @SQL + ', [MaMonHoc]'
				SET @SQL = @SQL + ' FROM [dbo].[PhuTrach]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaPhuTrach],'
				SET @SQL = @SQL + ' [MaGiaoVien],'
				SET @SQL = @SQL + ' [MaMonHoc]'
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
				SET @SQL = @SQL + ' FROM [dbo].[PhuTrach]'
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

	

-- Drop the dbo.PhuTrach_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhuTrach_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhuTrach_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the PhuTrach table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhuTrach_Insert
(

	@MaPhuTrach nvarchar (5)  ,

	@MaGiaoVien nvarchar (5)  ,

	@MaMonHoc nvarchar (4)  
)
AS


					
				INSERT INTO [dbo].[PhuTrach]
					(
					[MaPhuTrach]
					,[MaGiaoVien]
					,[MaMonHoc]
					)
				VALUES
					(
					@MaPhuTrach
					,@MaGiaoVien
					,@MaMonHoc
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhuTrach_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhuTrach_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhuTrach_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the PhuTrach table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhuTrach_Update
(

	@MaPhuTrach nvarchar (5)  ,

	@OriginalMaPhuTrach nvarchar (5)  ,

	@MaGiaoVien nvarchar (5)  ,

	@MaMonHoc nvarchar (4)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[PhuTrach]
				SET
					[MaPhuTrach] = @MaPhuTrach
					,[MaGiaoVien] = @MaGiaoVien
					,[MaMonHoc] = @MaMonHoc
				WHERE
[MaPhuTrach] = @OriginalMaPhuTrach 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhuTrach_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhuTrach_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhuTrach_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the PhuTrach table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhuTrach_Delete
(

	@MaPhuTrach nvarchar (5)  
)
AS


				DELETE FROM [dbo].[PhuTrach] WITH (ROWLOCK) 
				WHERE
					[MaPhuTrach] = @MaPhuTrach
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhuTrach_GetByMaPhuTrach procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhuTrach_GetByMaPhuTrach') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhuTrach_GetByMaPhuTrach
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the PhuTrach table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhuTrach_GetByMaPhuTrach
(

	@MaPhuTrach nvarchar (5)  
)
AS


				SELECT
					[MaPhuTrach],
					[MaGiaoVien],
					[MaMonHoc]
				FROM
					[dbo].[PhuTrach]
				WHERE
					[MaPhuTrach] = @MaPhuTrach
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhuTrach_GetByMaGiaoVien procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhuTrach_GetByMaGiaoVien') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhuTrach_GetByMaGiaoVien
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the PhuTrach table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhuTrach_GetByMaGiaoVien
(

	@MaGiaoVien nvarchar (5)  
)
AS


				SELECT
					[MaPhuTrach],
					[MaGiaoVien],
					[MaMonHoc]
				FROM
					[dbo].[PhuTrach]
				WHERE
					[MaGiaoVien] = @MaGiaoVien
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhuTrach_GetByMaMonHoc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhuTrach_GetByMaMonHoc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhuTrach_GetByMaMonHoc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the PhuTrach table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhuTrach_GetByMaMonHoc
(

	@MaMonHoc nvarchar (4)  
)
AS


				SELECT
					[MaPhuTrach],
					[MaGiaoVien],
					[MaMonHoc]
				FROM
					[dbo].[PhuTrach]
				WHERE
					[MaMonHoc] = @MaMonHoc
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.PhuTrach_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.PhuTrach_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.PhuTrach_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the PhuTrach table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.PhuTrach_Find
(

	@SearchUsingOR bit   = null ,

	@MaPhuTrach nvarchar (5)  = null ,

	@MaGiaoVien nvarchar (5)  = null ,

	@MaMonHoc nvarchar (4)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaPhuTrach]
	, [MaGiaoVien]
	, [MaMonHoc]
    FROM
	[dbo].[PhuTrach]
    WHERE 
	 ([MaPhuTrach] = @MaPhuTrach OR @MaPhuTrach is null)
	AND ([MaGiaoVien] = @MaGiaoVien OR @MaGiaoVien is null)
	AND ([MaMonHoc] = @MaMonHoc OR @MaMonHoc is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaPhuTrach]
	, [MaGiaoVien]
	, [MaMonHoc]
    FROM
	[dbo].[PhuTrach]
    WHERE 
	 ([MaPhuTrach] = @MaPhuTrach AND @MaPhuTrach is not null)
	OR ([MaGiaoVien] = @MaGiaoVien AND @MaGiaoVien is not null)
	OR ([MaMonHoc] = @MaMonHoc AND @MaMonHoc is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LichLopHoc_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LichLopHoc_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LichLopHoc_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the LichLopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LichLopHoc_Get_List

AS


				
				SELECT
					[MaLichLopHoc],
					[MaPhanCong],
					[Thu],
					[TietHocBatDau],
					[SoTietHoc]
				FROM
					[dbo].[LichLopHoc]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LichLopHoc_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LichLopHoc_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LichLopHoc_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the LichLopHoc table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LichLopHoc_GetPaged
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
					SET @OrderBy = '[MaLichLopHoc]'
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
				SET @SQL = @SQL + ', [MaLichLopHoc]'
				SET @SQL = @SQL + ', [MaPhanCong]'
				SET @SQL = @SQL + ', [Thu]'
				SET @SQL = @SQL + ', [TietHocBatDau]'
				SET @SQL = @SQL + ', [SoTietHoc]'
				SET @SQL = @SQL + ' FROM [dbo].[LichLopHoc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MaLichLopHoc],'
				SET @SQL = @SQL + ' [MaPhanCong],'
				SET @SQL = @SQL + ' [Thu],'
				SET @SQL = @SQL + ' [TietHocBatDau],'
				SET @SQL = @SQL + ' [SoTietHoc]'
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
				SET @SQL = @SQL + ' FROM [dbo].[LichLopHoc]'
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

	

-- Drop the dbo.LichLopHoc_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LichLopHoc_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LichLopHoc_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the LichLopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LichLopHoc_Insert
(

	@MaLichLopHoc nvarchar (8)  ,

	@MaPhanCong nvarchar (6)  ,

	@Thu nvarchar (50)  ,

	@TietHocBatDau tinyint   ,

	@SoTietHoc tinyint   
)
AS


					
				INSERT INTO [dbo].[LichLopHoc]
					(
					[MaLichLopHoc]
					,[MaPhanCong]
					,[Thu]
					,[TietHocBatDau]
					,[SoTietHoc]
					)
				VALUES
					(
					@MaLichLopHoc
					,@MaPhanCong
					,@Thu
					,@TietHocBatDau
					,@SoTietHoc
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LichLopHoc_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LichLopHoc_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LichLopHoc_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the LichLopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LichLopHoc_Update
(

	@MaLichLopHoc nvarchar (8)  ,

	@OriginalMaLichLopHoc nvarchar (8)  ,

	@MaPhanCong nvarchar (6)  ,

	@Thu nvarchar (50)  ,

	@TietHocBatDau tinyint   ,

	@SoTietHoc tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[LichLopHoc]
				SET
					[MaLichLopHoc] = @MaLichLopHoc
					,[MaPhanCong] = @MaPhanCong
					,[Thu] = @Thu
					,[TietHocBatDau] = @TietHocBatDau
					,[SoTietHoc] = @SoTietHoc
				WHERE
[MaLichLopHoc] = @OriginalMaLichLopHoc 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LichLopHoc_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LichLopHoc_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LichLopHoc_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the LichLopHoc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LichLopHoc_Delete
(

	@MaLichLopHoc nvarchar (8)  
)
AS


				DELETE FROM [dbo].[LichLopHoc] WITH (ROWLOCK) 
				WHERE
					[MaLichLopHoc] = @MaLichLopHoc
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LichLopHoc_GetByMaLichLopHoc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LichLopHoc_GetByMaLichLopHoc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LichLopHoc_GetByMaLichLopHoc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LichLopHoc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LichLopHoc_GetByMaLichLopHoc
(

	@MaLichLopHoc nvarchar (8)  
)
AS


				SELECT
					[MaLichLopHoc],
					[MaPhanCong],
					[Thu],
					[TietHocBatDau],
					[SoTietHoc]
				FROM
					[dbo].[LichLopHoc]
				WHERE
					[MaLichLopHoc] = @MaLichLopHoc
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LichLopHoc_GetByMaPhanCong procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LichLopHoc_GetByMaPhanCong') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LichLopHoc_GetByMaPhanCong
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LichLopHoc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LichLopHoc_GetByMaPhanCong
(

	@MaPhanCong nvarchar (6)  
)
AS


				SELECT
					[MaLichLopHoc],
					[MaPhanCong],
					[Thu],
					[TietHocBatDau],
					[SoTietHoc]
				FROM
					[dbo].[LichLopHoc]
				WHERE
					[MaPhanCong] = @MaPhanCong
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LichLopHoc_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LichLopHoc_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LichLopHoc_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the LichLopHoc table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LichLopHoc_Find
(

	@SearchUsingOR bit   = null ,

	@MaLichLopHoc nvarchar (8)  = null ,

	@MaPhanCong nvarchar (6)  = null ,

	@Thu nvarchar (50)  = null ,

	@TietHocBatDau tinyint   = null ,

	@SoTietHoc tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MaLichLopHoc]
	, [MaPhanCong]
	, [Thu]
	, [TietHocBatDau]
	, [SoTietHoc]
    FROM
	[dbo].[LichLopHoc]
    WHERE 
	 ([MaLichLopHoc] = @MaLichLopHoc OR @MaLichLopHoc is null)
	AND ([MaPhanCong] = @MaPhanCong OR @MaPhanCong is null)
	AND ([Thu] = @Thu OR @Thu is null)
	AND ([TietHocBatDau] = @TietHocBatDau OR @TietHocBatDau is null)
	AND ([SoTietHoc] = @SoTietHoc OR @SoTietHoc is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MaLichLopHoc]
	, [MaPhanCong]
	, [Thu]
	, [TietHocBatDau]
	, [SoTietHoc]
    FROM
	[dbo].[LichLopHoc]
    WHERE 
	 ([MaLichLopHoc] = @MaLichLopHoc AND @MaLichLopHoc is not null)
	OR ([MaPhanCong] = @MaPhanCong AND @MaPhanCong is not null)
	OR ([Thu] = @Thu AND @Thu is not null)
	OR ([TietHocBatDau] = @TietHocBatDau AND @TietHocBatDau is not null)
	OR ([SoTietHoc] = @SoTietHoc AND @SoTietHoc is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

