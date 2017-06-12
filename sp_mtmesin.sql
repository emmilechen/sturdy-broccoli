USE [boxtree]
GO

/****** Object:  StoredProcedure [dbo].[sp_mt_mesin]    Script Date: 6/12/2017 12:51:11 PM ******/
DROP PROCEDURE [dbo].[sp_mt_mesin]
GO

/****** Object:  StoredProcedure [dbo].[sp_mt_mesin]    Script Date: 6/12/2017 12:51:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Yulius
-- Create date: 6/7/2013
-- Description:	Insert, Update, Delete, Select mt_mesin
-- =============================================
CREATE PROCEDURE [dbo].[sp_mt_mesin] 
	-- Add the parameters for the stored procedure here
	@action VARCHAR(10)
	,@created datetime= null
	,@createdby  nvarchar(50)= null
	,@modified datetime= null
	,@modifiedby  nvarchar(50)= null
	,@idmesin  nvarchar(50)
	,@katmesin  nvarchar(50)= null
	,@subkatmesin  nvarchar(50)= null
	,@tipemesin  nvarchar(50)= null
	,@namamesin  nvarchar(100)= null
	,@merekmesin  nvarchar(50)= null
	,@nomesin  nvarchar(50)= null
	,@tahun money= null
	,@dayalistrikval money= null
	,@dayalistrikuom nvarchar(50)= null
	,@kwhval money= null
	,@kwhuom nvarchar(50)= null
	,@teganganval money= null
	,@teganganuom nvarchar(50)= null
	,@frekuensival money= null
	,@frekuensiuom nvarchar(50)= null
	,@colourmesinval money= null
	,@colourmesinuom nvarchar(50)= null
	,@imageareaval money= null
	,@imageareauom nvarchar(50)= null
	,@sizeminval money= null
	,@sizeminuom  nvarchar(50)= null
	,@sizemaxval money= null
	,@sizemaxuom  nvarchar(50)= null
	,@speedminval money= null
	,@speedminuom  nvarchar(50)= null
	,@speedmaxval money= null
	,@speedmaxuom  nvarchar(50)= null
	,@targetminval money= null
	,@targetminuom  nvarchar(50)= null
	,@targetmaxval money= null
	,@targetmaxuom  nvarchar(50)= null
	,@c_id int OUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF (@action = 'select')
	BEGIN
		IF (@idmesin = '*')
			BEGIN
				declare @sql nvarchar(500)
				set @sql='SELECT idmesin, katmesin, subkatmesin, tipemesin, namamesin, merekmesin, 
				nomesin, tahun, dayalistrikval, dayalistrikuom, kwhval, kwhuom, teganganval, teganganuom, frekuensival, frekuensiuom, colourmesinval, 
				colourmesinuom, imageareaval, imageareauom, sizeminval, sizeminuom, sizemaxval, sizemaxuom, speedminval, speedminuom, speedmaxval, 
				speedmaxuom, targetminval, targetminuom, targetmaxval, targetmaxuom, created, createdby, modified, modifiedby
							FROM mt_mesin where mt_mesin.idmesin<>''*'''

				if @katmesin is not null
					set @sql=@sql+' and katmesin like ''%'+@katmesin+'%'''
				if @subkatmesin is not null
					set @sql=@sql+' and subkatmesin like ''%'+@subkatmesin+'%'''
				if @tipemesin is not null
					set @sql=@sql+' and tipemesin like ''%'+@tipemesin+'%'''
				if @namamesin is not null
					set @sql=@sql+' and namamesin like ''%'+@namamesin+'%'''
				if @merekmesin is not null
					set @sql=@sql+' and merekmesin like ''%'+@merekmesin+'%'''
				if @nomesin is not null
					set @sql=@sql+' and nomesin like ''%'+@nomesin+'%'''
				
				set @sql=@sql+' order by idmesin'
				exec(@sql)
			END
		ELSE IF (@idmesin <> '*')
			BEGIN
				SELECT created, createdby, modified, modifiedby, idmesin, katmesin, subkatmesin, tipemesin, namamesin, merekmesin, nomesin, tahun, dayalistrikval, dayalistrikuom, kwhval, kwhuom, teganganval, teganganuom, frekuensival, frekuensiuom, colourmesinval, colourmesinuom, imageareaval, imageareauom, sizeminval, sizeminuom, sizemaxval, sizemaxuom, speedminval, speedminuom, speedmaxval, speedmaxuom, targetminval, targetminuom, targetmaxval, targetmaxuom
				FROM mt_mesin
				WHERE idmesin = @idmesin
			END
	END
	ELSE IF (@action = 'insert')
	BEGIN		
		-- Insert statements for procedure here
		DECLARE @currentdate DATETIME
		SET @currentdate = GETDATE()
		insert into mt_mesin
		(
		created, createdby, modified, modifiedby, idmesin, katmesin, subkatmesin, tipemesin, namamesin, merekmesin, nomesin, tahun, dayalistrikval, dayalistrikuom, kwhval, kwhuom, teganganval, teganganuom, frekuensival, frekuensiuom, colourmesinval, colourmesinuom, imageareaval, imageareauom, sizeminval, sizeminuom, sizemaxval, sizemaxuom, speedminval, speedminuom, speedmaxval, speedmaxuom, targetminval, targetminuom, targetmaxval, targetmaxuom
		)
		values
		(
		@created, @createdby,  @modified, @modifiedby, @idmesin, @katmesin, @subkatmesin, @tipemesin, @namamesin, @merekmesin, @nomesin, @tahun, @dayalistrikval, @dayalistrikuom, @kwhval, @kwhuom, @teganganval, @teganganuom, @frekuensival, @frekuensiuom, @colourmesinval, @colourmesinuom, @imageareaval, @imageareauom, @sizeminval, @sizeminuom, @sizemaxval, @sizemaxuom, @speedminval, @speedminuom, @speedmaxval, @speedmaxuom, @targetminval, @targetminuom, @targetmaxval, @targetmaxuom
		)
	END
ELSE IF (@action = 'update')
	BEGIN
		UPDATE mt_mesin
		SET katmesin = @katmesin, subkatmesin = @subkatmesin,
			tipemesin = @tipemesin, namamesin = @namamesin, merekmesin = @merekmesin
		WHERE idmesin = @idmesin
	END
ELSE IF  (@action = 'delete')
	BEGIN
		DELETE
		FROM mt_mesin
		WHERE idmesin = @idmesin
	END

	set @c_id = SCOPE_IDENTITY()
END


GO


