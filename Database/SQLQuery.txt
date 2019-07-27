create database dbproject
use dbproject

CREATE TABLE tbl_Controller(
		[ctrl_ID] [int] IDENTITY(1,1) NOT NULL,
		[ctrl_Name] [nvarchar](max) NOT NULL,
		[ctrl_UserName] [nvarchar](max) NOT NULL,
		[ctrl_Password] [nvarchar](max) NOT NULL,
		PRIMARY KEY (ctrl_ID) 
    );
    
    
INSERT INTO tbl_Controller VALUES( 'admin','admin'  ,'admin' )


CREATE TABLE tbl_Category(
		[Category_ID] [int] IDENTITY(1,1) NOT NULL,
		[Category_name] [nvarchar](max) NOT NULL,
		[Category_Description] [nvarchar](max) NOT NULL,
		PRIMARY KEY (Category_ID) 
	);
	
CREATE TABLE tbl_SubCategory(
		[SubCategory_ID] [int] IDENTITY(1,1) NOT NULL,
		[SubCategory_Name] [nvarchar](max) NOT NULL,
		[SubCategory_Description] [nvarchar](max) NOT NULL,
		[Category_ID] [int] NOT NULL,
		PRIMARY KEY (SubCategory_ID),
		FOREIGN KEY (Category_ID) REFERENCES tbl_Category(Category_ID)
	);

CREATE TABLE tbl_Product(
		[Product_ID] [int] IDENTITY(1,1) NOT NULL,
		[Product_Name] [nvarchar](max) NOT NULL,
		[Product_Type] [nvarchar](max) NOT NULL,
		[Product_Code] [nvarchar](max) NOT NULL,
		[Product_SeqCode] [nvarchar](max) NOT NULL,
		[Product_MinStockLevel] [money] NOT NULL,
		[Product_SellingRate] [money] NOT NULL,
		[Product_ReorderQty] [money] NOT NULL,
		[Category_ID] [int] NOT NULL,
		[SubCategory_ID] [int] NOT NULL,
		PRIMARY KEY (Product_ID),		
		FOREIGN KEY (Category_ID) REFERENCES tbl_Category(Category_ID) , 
		FOREIGN KEY (SubCategory_ID) REFERENCES tbl_SubCategory(SubCategory_ID)		
	);


CREATE TABLE tbl_Customer(
		[Cust_ID] [int] IDENTITY(1,1) NOT NULL,
		[Cust_Name] [nvarchar](max) NOT NULL,
		[Cust_MobileNo] [nvarchar](max) NOT NULL,
		[Cust_Address1] [nvarchar](max) NOT NULL,
		[Cust_Address2] [nvarchar](max) NOT NULL,
		[Cust_Fax] [nvarchar](max) NOT NULL,
		[Cust_Remarks] [nvarchar](max) NOT NULL,
		[Cust_City] [nvarchar](max) NOT NULL,
		[Cust_EmailID] [nvarchar](max) NOT NULL,
		[Cust_CustomerCode] [nvarchar](max) NOT NULL
		PRIMARY KEY (Cust_ID)
	);

CREATE TABLE tbl_UnitMeasure(
		[UnitMeasure_ID] [int] IDENTITY(1,1) NOT NULL,
		[UnitMeasure_Name] [nvarchar](max) NOT NULL,
		PRIMARY KEY (UnitMeasure_ID)
	);


CREATE TABLE tbl_Stock(
		[S_ID] [int] IDENTITY(1,1) NOT NULL,
		[S_Rate] [money] NOT NULL,
		[S_SIH] [money] NOT NULL,
		[UnitMeasure_ID] [int] NOT NULL,
		[Product_ID] [int] NOT NULL,
		PRIMARY KEY (S_ID) , 
		FOREIGN KEY (UnitMeasure_ID) REFERENCES tbl_UnitMeasure(UnitMeasure_ID) , 
		FOREIGN KEY (Product_ID) REFERENCES tbl_Product(Product_ID) 
	);

CREATE TABLE tbl_Transaction(
		[T_ID] [int] IDENTITY(1,1) NOT NULL,
		[T_Date] [date] NOT NULL,
		[Cust_ID] [int] NOT NULL , 
		[billAmount] [money] NOT NULL ,
		PRIMARY KEY (T_ID) , 
		FOREIGN KEY (Cust_ID) REFERENCES tbl_Customer(Cust_ID) 
	);
	
CREATE TABLE tbl_Transaction_Products(
		[TP_ID] [int] IDENTITY(1,1) NOT NULL,
		[TP_Quantity] [money] NOT NULL,
		[TP_Amount] [money] NOT NULL,
		[Product_ID] [int] NOT NULL,
		[T_ID] [int] NOT NULL,
		PRIMARY KEY (TP_ID) , 
		FOREIGN KEY (Product_ID) REFERENCES tbl_Product(Product_ID) ,
		FOREIGN KEY (T_ID) REFERENCES tbl_Transaction(T_ID) 
	);
	
	

-----------------------
-- Stored Procedures --
-----------------------

	-------
	-- 1 --
	-------
	CREATE PROCEDURE strpdCheckLoginCredentials 
		@userName as nvarchar(max) , 
		@password as nvarchar(max)  
	AS
	BEGIN
		SET NOCOUNT ON;
		if exists(
				   select tbl_Controller.ctrl_ID 
				   from tbl_Controller 
				   where tbl_Controller.ctrl_UserName = @userName AND tbl_Controller.ctrl_Password = @password
				  )
			begin 
				select 1 
			end 
		else 
			begin 
				select -1
			end 
	END
	
	
	-------
	-- 2 --
	-------
	CREATE PROCEDURE strpdGetAllCategoriesDetails
	AS
	BEGIN
		SELECT Category_ID
		  ,Category_name
		  ,Category_Description
		 FROM tbl_Category    
	END
	



	-------
	-- 3 --
	-------
	CREATE PROCEDURE [dbo].[strpdAddUpdateCategories]
		@categoryName nvarchar(max) , 
		@categoryDesc nvarchar(max) , 
        @IDToUpdate int , 
        @flag int
	AS
	BEGIN
		SET NOCOUNT ON;
		
					if(@flag = 0)		-- ADD
						begin 
							if exists (
										select Category_ID 
										from tbl_Category 
										where tbl_Category.Category_name = @categoryName
									   )
								begin 
									select -1 
								end
							else 
								begin 
									insert into dbo.tbl_Category
									values (@categoryName , @categoryDesc)
									
									select 1 
								end 
						end 
					else if (@flag = 1)		--UPDATE
						begin 
							Update tbl_Category
							set tbl_Category.Category_name = @categoryName ,
							 tbl_Category.Category_Description = @categoryDesc
							where tbl_Category.Category_ID = @IDToUpdate


									select 2 

						end 
	END

	-------
	-- 4 --
	-------
	CREATE PROCEDURE strpdGetAllCategories
	AS
	BEGIN
		select Category_ID ,Category_name
		from tbl_Category
	END
	
	-------
	-- 5 --
	-------
	CREATE PROCEDURE  strpdGetAllSubCategories
	AS
	BEGIN
	SELECT SubCategory_ID
		  ,SubCategory_Name
	  FROM tbl_SubCategory
	END

	-------
	-- 6 --
	-------
	CREATE PROCEDURE strpdGetAllSubCategoriesDetails
	AS
	BEGIN
		SELECT [SubCategory_ID] as [ID] 
			  ,[SubCategory_Name] as [Name] 
			  ,[SubCategory_Description] as [ Description ]  
			  ,tbl_Category.Category_name as [ Category Name ]
		  FROM tbl_SubCategory
		  inner join tbl_Category 
		  on tbl_Category.Category_ID =  tbl_SubCategory.Category_ID 
	END


		
	-------
	-- 7 --
	-------
	CREATE PROCEDURE strpdAddUpdateSubCategories
		@categoryName nvarchar(max) ,
		@subCategoryName nvarchar(max) , 
		@subCategoryDesc nvarchar(max) , 
        @IDToUpdate int , 
        @flag int

	AS
		declare @categoryID int 
	BEGIN
				select @categoryID = tbl_Category.Category_ID 
				from tbl_Category 
				where tbl_Category.Category_name = @categoryName
				
				if(@flag = 0)		-- ADD
					begin 
						if exists (
							select tbl_SubCategory.SubCategory_ID 
							from tbl_SubCategory
							inner join tbl_Category
							on tbl_Category.Category_ID = tbl_SubCategory.Category_ID
							where tbl_SubCategory.SubCategory_Name = @subCategoryName 
							and tbl_Category.Category_name = @categoryName
						)
						begin 
							select -1 
						end
						else 
								begin 
									insert into dbo.tbl_SubCategory
									values (@subCategoryName , @subCategoryDesc , @categoryID)
									select 3 
								end 
						end 
				else if (@flag = 1)		--UPDATE
				begin 
					Update tbl_SubCategory
						set tbl_SubCategory.SubCategory_Name = @subCategoryName , 
						tbl_SubCategory.SubCategory_Description = @subCategoryDesc , 
						tbl_SubCategory.Category_ID = @categoryID 
						where tbl_SubCategory.SubCategory_ID = @IDToUpdate
						select 2 
				end 
	END

	-------
	-- 8 --
	-------
	CREATE PROCEDURE strpdGetAllUnitMeasureDetails 
	AS
	BEGIN
		select 
		tbl_UnitMeasure.UnitMeasure_ID as [ ID ] , 
		tbl_UnitMeasure.UnitMeasure_Name as [ Name ]
		from tbl_UnitMeasure
	END
	
	
	
	
	-------
	-- 9 --
	-------
	CREATE PROCEDURE strpdAddUpdateUnitMeasure
		@unitMeasure as nvarchar(MAX )  ,
		@IDToUpdate as int  , 
		@flag as int 
	AS
	BEGIN
		if(@flag = 0 )
		begin
			insert into tbl_UnitMeasure 
			values (@unitMeasure)  
		end 
		else 
		begin  
			update tbl_UnitMeasure 
			set UnitMeasure_Name = @unitMeasure 
			where UnitMeasure_ID = @idToUpdate
		end 
	END
	
	--------
	-- 10 --
	--------
	CREATE PROCEDURE strpdAddUpdateCustomerDetails 
		@CustomerName as nvarchar(max), 
		@MobileNO as nvarchar(max),  
		@Address as nvarchar(max),  
		@Address2 as nvarchar(max),  
		@FaxNumber as nvarchar(max),  
		@Remarks as nvarchar(max),  
		@City as nvarchar(max),  
		@EmailID as nvarchar(max),  
		@CustomerCOde as nvarchar(max),  
		@idToUpdate as int , 
		@flag as int 
	AS
	BEGIN
		if(@flag = 0 )
			begin 
				insert into tbl_Customer 
				values (
							@CustomerName , 
							@MobileNO , 
							@Address ,
							@Address2 , 
							@FaxNumber , 
							@Remarks,
							@City , 
							@EmailID , 
							@CustomerCOde
						 ) 
				end 
			else 
				begin 
						update tbl_Customer
						set Cust_Name =  @CustomerName , 
						Cust_Address1 =  @Address, 
						Cust_Address2 =  @Address2, 
						Cust_Fax =  @FaxNumber, 
						Cust_Remarks =  @Remarks, 
						Cust_City =  @City, 
						Cust_MobileNo =  @MobileNO, 
						Cust_EmailID = @EmailID  , 
						Cust_CustomerCode = @CustomerCOde 
				end 

	END
	
	--------
	-- 11 --
	--------
	CREATE PROCEDURE strpdGetAllCustomersDetails
	AS
	BEGIN
			SELECT Cust_ID as [ID] ,
			  Cust_Name as [Name] ,
			  Cust_MobileNo as [Mobile No],
			  Cust_Address1 as [Address 1],
			  Cust_Address2 as [Address 2],
			  Cust_Fax as [Fax],
			  Cust_Remarks as [Remarks],
			  Cust_EmailID  as [Email ID],
			  Cust_City as [City],
			  Cust_CustomerCode as [ Customer Code]
		  FROM tbl_Customer
	END

	--------
	-- 12 --
	--------
	CREATE PROCEDURE [dbo].[strpdAddUpdateProducts]
			@ItemName as nvarchar(max) , 
			@ItemCode as nvarchar(max) , 
			@SeqNo as nvarchar(max) , 
			@MinLevelStock as int ,
			@ReorderQty as int ,
			@Remarks as nvarchar(max) , 
			@Type as nvarchar(max) , 
			@CategoryID as int ,
			@SubCategoryID as int ,
			@sellingRate as money ,
			@IDToUpdate as int ,
			@flag as int 
		AS
		BEGIN
			if(@flag = 0  )
			begin 
				insert into tbl_Product
				values ( 
							@ItemName , 
							@Type , 
							@ItemCode ,
							@SeqNo ,
							@MinLevelStock , 
							@sellingRate,
							@ReorderQty , 
							@CategoryID , 
							@SubCategoryID 
						) 
			end 
			else 
			begin 
				update tbl_Product
				set 
				Product_Name = @ItemName , 
				Product_Type = @Type , 
				Product_Code = @ItemCode , 
				Product_SeqCode = @SeqNo , 
				Product_MinStockLevel = @MinLevelStock  , 
				Product_ReorderQty = @ReorderQty , 
				Category_ID = @CategoryID , 
				SubCategory_ID = @SubCategoryID ,
				Product_SellingRate = @sellingRate
			end 
			

		END


	--------
	-- 13 --
	--------
	CREATE PROCEDURE  strpdGetAllSubCategoriesForThisCategory
		@CategoryID as int 
	AS
	BEGIN
		  SELECT SubCategory_ID , 
	   		  SubCategory_Name
		  FROM tbl_SubCategory
		  where tbl_SubCategory.Category_ID = @CategoryID
	END


	--------
	-- 14 --
	--------		
	CREATE PROCEDURE  strpdAddUpdateStockDetails
          @amount AS money ,
          @rate  AS money ,
          @quantity  AS money ,
          @product_ID AS int ,
          @unit_ID AS int  ,
          @productName as nvarchar(max), 
		  @idToUpdaate as int , 
          @flag as int  
	AS
		declare @Last_SIH money 
		declare @product_ID_ToUpdate int
		
	BEGIN
		  select @Last_SIH  = tbl_Stock.S_SIH
		  from tbl_Stock
		  where tbl_Stock.Product_ID = @product_ID 

			if(@flag = 0 )		-- ADD Stock
			Begin
					if exists( 
							select tbl_Stock.S_ID
							from  tbl_Stock
							where tbl_Stock.Product_ID= @product_ID 
						)
						begin	-- product alredy added just update stock 
							-- get last stock for this product and godown 
							update tbl_Stock
							set tbl_Stock.S_SIH = (@Last_SIH + @quantity )
							where tbl_Stock.Product_ID = @product_ID 
						end
					else 
						begin		-- first time entry of this product in this godown  (insert) 
							insert into tbl_Stock
							values (
								@rate , 
								@quantity , 
								@unit_ID , 
								@product_ID  
							) 
						end
						
			End 
			ELSE if (@flag = 1 ) 		-- UPDATE STOCK	 (minus from stock)
			BEGIN
			
				select @product_ID_ToUpdate = tbl_Product.Product_ID
				from tbl_Product 
				where tbl_Product.Product_Name = @productName
			
			
				select @Last_SIH  = tbl_Stock.S_SIH
			    from tbl_Stock
			    where tbl_Stock.Product_ID = @product_ID_ToUpdate 

				update tbl_Stock
				set tbl_Stock.S_SIH = (@Last_SIH - @quantity)
				where tbl_Stock.Product_ID = @product_ID_ToUpdate 
			END 	
	END

	--------
	-- 15 --
	--------		
	CREATE PROCEDURE strpdGetAllProductNames 
	AS
	BEGIN
		SELECT Product_ID,
			   Product_Name
		  FROM tbl_Product
	END

	--------
	-- 16 --
	--------
	CREATE PROCEDURE strpdGetAllUnitmeasures
	AS
	BEGIN
		SELECT UnitMeasure_ID, 
		       UnitMeasure_Name
		  FROM tbl_UnitMeasure
	END
	
	--------
	-- 17 --
	--------
	CREATE PROCEDURE strpdGetAllStockDetails
	AS
	BEGIN
		select 
			tbl_Product.Product_Name as [Item Name] , 
			tbl_Stock.S_SIH as [Stock In Hand],  
			tbl_UnitMeasure.UnitMeasure_Name as [Unit] 
		from tbl_Stock
		inner join tbl_Product
		on tbl_Product.Product_ID = tbl_Stock.Product_ID 
		inner join tbl_UnitMeasure 
		on tbl_UnitMeasure.UnitMeasure_ID = tbl_Stock.UnitMeasure_ID
	END
	
	--------
	-- 18 --
	--------
	CREATE PROCEDURE strpdAddUpdateTransactionDetails
		@TransactionDate as Date , 
		@Cust_ID as int , 
		@billAmount as money
	AS
	BEGIN
		insert into tbl_Transaction 
		values (
			@TransactionDate , 
			@Cust_ID , 
			@billAmount
		) 
	END
	
	--------
	-- 19 --
	--------
	CREATE PROCEDURE strpdAddUpdateTransactionProductDetails
		@Quantity as money, 
		@Amount as money,  
		@poductName as nvarchar(max) 
	AS
		declare @product_ID int
	BEGIN
		select @product_ID = tbl_Product.Product_ID 
		from tbl_Product 
		where tbl_Product.Product_Name = @poductName

		insert into tbl_Transaction_Products
		values (
			@Quantity, 
			@Amount , 
			@product_ID ,
			IDENT_CURRENT('tbl_Transaction')
		) 
	END
	
	--------
	-- 20 --
	--------	
	CREATE PROCEDURE strpdGetProductStockInHand
		@product_ID as int 
	AS
	BEGIN
		select tbl_Stock.S_SIH as [Stock In Hand]
		from tbl_Stock	
		where tbl_Stock.Product_ID = @product_ID 
	END


	--------
	-- 21 --
	--------	
	CREATE PROCEDURE strpdGetSellingRatesOfProduct
		@product_ID as int 
	AS
	BEGIN
		select tbl_Product.Product_SellingRate as [Selling Rate]
		from tbl_Product
		where tbl_Product.Product_ID = @product_ID 
	END

	--------
	-- 22 --
	--------	
	CREATE PROCEDURE strpdGetAllCustomerNames
	AS
	BEGIN
		select tbl_Customer.Cust_Name , 
				tbl_Customer.Cust_ID
 		from tbl_Customer
	END

	
