
if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Area')
            and   type = 'U')
   drop table dbo.Area
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FunctionGroup')
            and   type = 'U')
   drop table FunctionGroup
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InvTransaction')
            and   type = 'U')
   drop table InvTransaction
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Inventory')
            and   type = 'U')
   drop table dbo.Inventory
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ItemBrand')
            and   type = 'U')
   drop table ItemBrand
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ItemClass')
            and   type = 'U')
   drop table ItemClass
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.ItemFeedback')
            and   type = 'U')
   drop table dbo.ItemFeedback
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.ItemProperty')
            and   type = 'U')
   drop table dbo.ItemProperty
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Items')
            and   type = 'U')
   drop table Items
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.MemberComment')
            and   type = 'U')
   drop table dbo.MemberComment
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.MemberLevel')
            and   type = 'U')
   drop table dbo.MemberLevel
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.MemberOrder')
            and   type = 'U')
   drop table dbo.MemberOrder
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.MemberOrderDetail')
            and   type = 'U')
   drop table dbo.MemberOrderDetail
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Members')
            and   type = 'U')
   drop table dbo.Members
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PurchaseOrder')
            and   type = 'U')
   drop table dbo.PurchaseOrder
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PurchaseOrderDetail')
            and   type = 'U')
   drop table dbo.PurchaseOrderDetail
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.RoleFunction')
            and   type = 'U')
   drop table dbo.RoleFunction
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Roles')
            and   type = 'U')
   drop table dbo.Roles
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SalesOrder')
            and   type = 'U')
   drop table dbo.SalesOrder
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SalesOrderDetail')
            and   type = 'U')
   drop table dbo.SalesOrderDetail
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Suppliers')
            and   type = 'U')
   drop table dbo.Suppliers
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysCode')
            and   type = 'U')
   drop table dbo.SysCode
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysSetting')
            and   type = 'U')
   drop table dbo.SysSetting
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.UserRole')
            and   type = 'U')
   drop table dbo.UserRole
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.UserSupplier')
            and   type = 'U')
   drop table dbo.UserSupplier
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Users')
            and   type = 'U')
   drop table dbo.Users
go

/*==============================================================*/
/* User: dbo                                                    */
/*==============================================================*/
execute sp_grantdbaccess dbo
go

/*==============================================================*/
/* Table: Area                                                  */
/*==============================================================*/
create table dbo.Area (
   ID                   int                  identity,
   AreaCode             nvarchar(20)         not null,
   AreaName             nvarchar(20)         not null,
   IsActive             bit                  not null,
   Remark               nvarchar(50)         null,
   CreatedBy            nvarchar(20)         null,
   CretaedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_AREA primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '区域',
   'user', 'dbo', 'table', 'Area'
go

execute sp_addextendedproperty 'MS_Description', 
   '自增主键',
   'user', 'dbo', 'table', 'Area', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '区域代码',
   'user', 'dbo', 'table', 'Area', 'column', 'AreaCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '区域名称',
   'user', 'dbo', 'table', 'Area', 'column', 'AreaName'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否启用',
   'user', 'dbo', 'table', 'Area', 'column', 'IsActive'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'Area', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', 'dbo', 'table', 'Area', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'Area', 'column', 'CretaedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新人',
   'user', 'dbo', 'table', 'Area', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新日期',
   'user', 'dbo', 'table', 'Area', 'column', 'UpdatedDate'
go

/*==============================================================*/
/* Table: FunctionGroup                                         */
/*==============================================================*/
create table FunctionGroup (
   FunctionID           int                  identity,
   ParentID             nvarchar(10)         null,
   FunctionName         nvarchar(20)         null,
   SeqNo                int                  null,
   GroupLevel           int                  null,
   Url                  nvarchar(50)         null,
   PageID               nvarchar(30)         null,
   PageName             nvarchar(30)         null,
   ButtonID             nvarchar(30)         null,
   ButtonName           nvarchar(30)         null,
   constraint PK_FUNCTIONGROUP primary key (FunctionID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '节点',
   'user', '', 'table', 'FunctionGroup', 'column', 'FunctionID'
go

execute sp_addextendedproperty 'MS_Description', 
   '父节点',
   'user', '', 'table', 'FunctionGroup', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '节点名称',
   'user', '', 'table', 'FunctionGroup', 'column', 'FunctionName'
go

execute sp_addextendedproperty 'MS_Description', 
   '顺序',
   'user', '', 'table', 'FunctionGroup', 'column', 'SeqNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '层级代码',
   'user', '', 'table', 'FunctionGroup', 'column', 'GroupLevel'
go

execute sp_addextendedproperty 'MS_Description', 
   '页面链接',
   'user', '', 'table', 'FunctionGroup', 'column', 'Url'
go

execute sp_addextendedproperty 'MS_Description', 
   '页面代码',
   'user', '', 'table', 'FunctionGroup', 'column', 'PageID'
go

execute sp_addextendedproperty 'MS_Description', 
   '页面名称',
   'user', '', 'table', 'FunctionGroup', 'column', 'PageName'
go

execute sp_addextendedproperty 'MS_Description', 
   '按钮代码',
   'user', '', 'table', 'FunctionGroup', 'column', 'ButtonID'
go

execute sp_addextendedproperty 'MS_Description', 
   '按钮名称',
   'user', '', 'table', 'FunctionGroup', 'column', 'ButtonName'
go

/*==============================================================*/
/* Table: InvTransaction                                        */
/*==============================================================*/
create table InvTransaction (
   TransID              int                  identity,
   ItemID               int                  null,
   SupplierID           int                  null,
   TransType            nvarchar(20)         null,
   Qty                  int                  null,
   PoID                 nvarchar(20)         null,
   PoLineID             nvarchar(20)         null,
   SoID                 nvarchar(20)         null,
   SoLineID             nvarchar(20)         null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   constraint PK_INVTRANSACTION primary key (TransID)
)
go

declare @CmtInvTransaction varchar(128)
select @CmtInvTransaction = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '商品库存交易表
   商品的进出都要记录一条交易，用于后期跟踪和报表',
   'user', @CmtInvTransaction, 'table', 'InvTransaction'
go

execute sp_addextendedproperty 'MS_Description', 
   '自增主键',
   'user', '', 'table', 'InvTransaction', 'column', 'TransID'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品代码',
   'user', '', 'table', 'InvTransaction', 'column', 'ItemID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供应商代码',
   'user', '', 'table', 'InvTransaction', 'column', 'SupplierID'
go

execute sp_addextendedproperty 'MS_Description', 
   '交易类型',
   'user', '', 'table', 'InvTransaction', 'column', 'TransType'
go

execute sp_addextendedproperty 'MS_Description', 
   '数量',
   'user', '', 'table', 'InvTransaction', 'column', 'Qty'
go

execute sp_addextendedproperty 'MS_Description', 
   '采购订单号',
   'user', '', 'table', 'InvTransaction', 'column', 'PoID'
go

execute sp_addextendedproperty 'MS_Description', 
   '采购订单行号',
   'user', '', 'table', 'InvTransaction', 'column', 'PoLineID'
go

execute sp_addextendedproperty 'MS_Description', 
   '销售订单号',
   'user', '', 'table', 'InvTransaction', 'column', 'SoID'
go

execute sp_addextendedproperty 'MS_Description', 
   '销售订单行号',
   'user', '', 'table', 'InvTransaction', 'column', 'SoLineID'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', '', 'table', 'InvTransaction', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', '', 'table', 'InvTransaction', 'column', 'CreatedDate'
go

/*==============================================================*/
/* Table: Inventory                                             */
/*==============================================================*/
create table dbo.Inventory (
   ID                   int                  identity,
   ItemID               int                  not null,
   Qty                  int                  not null,
   OrderQty             int                  null,
   TS                   timestamp            null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_INVENTORY primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '供应商商品库存表',
   'user', 'dbo', 'table', 'Inventory'
go

/*==============================================================*/
/* Table: ItemBrand                                             */
/*==============================================================*/
create table ItemBrand (
   BrandID              int                  identity,
   BrandName            nvarchar(20)         not null,
   IsActive             bit                  null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_ITEMBRAND primary key (BrandID)
)
go

declare @CmtItemBrand varchar(128)
select @CmtItemBrand = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '商品品牌',
   'user', @CmtItemBrand, 'table', 'ItemBrand'
go

/*==============================================================*/
/* Table: ItemClass                                             */
/*==============================================================*/
create table ItemClass (
   ClassID              int                  identity,
   ClassName            nvarchar(20)         not null,
   IsActive             bit                  null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_ITEMCLASS primary key (ClassID)
)
go

declare @CmtItemClass varchar(128)
select @CmtItemClass = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '商品分类',
   'user', @CmtItemClass, 'table', 'ItemClass'
go

/*==============================================================*/
/* Table: ItemFeedback                                          */
/*==============================================================*/
create table dbo.ItemFeedback (
   ID                   int                  identity,
   SupplierID           nvarchar(20)         not null,
   ItemID               nvarchar(20)         not null,
   Title                nvarchar(50)         not null,
   Content              nvarchar(500)        null,
   Reply                nvarchar(500)        null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   ReplyBy              nvarchar(20)         null,
   ReplyDate            datetime             null,
   constraint PK_ITEMFEEDBACK primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '商品咨询留言',
   'user', 'dbo', 'table', 'ItemFeedback'
go

/*==============================================================*/
/* Table: ItemProperty                                          */
/*==============================================================*/
create table dbo.ItemProperty (
   ID                   int                  null,
   Property             nvarchar(20)         null
)
go

execute sp_addextendedproperty 'MS_Description', 
   '商品属性',
   'user', 'dbo', 'table', 'ItemProperty'
go

/*==============================================================*/
/* Table: Items                                                 */
/*==============================================================*/
create table Items (
   ItemID               int                  identity,
   SupplierID           int                  not null,
   ItemCode             nvarchar(20)         not null,
   ItemName             nvarchar(50)         not null,
   ItemDescription      nvarchar(100)        null,
   ItemSynopsis         nvarchar(500)        null,
   ItemCharacter        nvarchar(20)         null,
   ItemClassID          nvarchar(20)         null,
   ItemBrandID          nvarchar(20)         null,
   GrossWgt             decimal(22,7)        null,
   NetWgt               decimal(22,7)        null,
   Length               decimal(22,7)        null,
   Width                decimal(22,7)        null,
   Height               decimal(22,7)        null,
   Cube                 decimal(22,7)        null,
   UomID                nvarchar(10)         null,
   AreaID               nvarchar(20)         null,
   CostPrice            decimal(22,7)        null,
   MarketPrice          decimal(22,7)        null,
   AdvicePrice          decimal(22,7)        null,
   SalesPrice           decimal(22,7)        null,
   ItemStyle            nvarchar(20)         null,
   ItemColor            nvarchar(20)         null,
   ItemSize             nvarchar(20)         null,
   PresentPoints        int                  null,
   PhotoUrl             nvarchar(100)        null,
   Remark               nvarchar(300)        null,
   IsActive             nvarchar(1)          null,
   IsAudited            nvarchar(1)          null,
   BillingType          nvarchar(20)         null,
   CreatedBy            int                  null,
   CreatedDate          datetime             null,
   UpdatedBy            int                  null,
   UpdatedDate          datetime             null,
   constraint PK_ITEMS primary key (ItemID)
)
go

declare @CmtItems varchar(128)
select @CmtItems = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '商品表
   供应商 ＋ 商品代码  为主键',
   'user', @CmtItems, 'table', 'Items'
go

execute sp_addextendedproperty 'MS_Description', 
   '自增主键',
   'user', '', 'table', 'Items', 'column', 'ItemID'
go

execute sp_addextendedproperty 'MS_Description', 
   '供应商代码',
   'user', '', 'table', 'Items', 'column', 'SupplierID'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品代码',
   'user', '', 'table', 'Items', 'column', 'ItemCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品名称',
   'user', '', 'table', 'Items', 'column', 'ItemName'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品描述',
   'user', '', 'table', 'Items', 'column', 'ItemDescription'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品简介',
   'user', '', 'table', 'Items', 'column', 'ItemSynopsis'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品性质，如实体商品，虚拟商品',
   'user', '', 'table', 'Items', 'column', 'ItemCharacter'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品分类',
   'user', '', 'table', 'Items', 'column', 'ItemClassID'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品品牌',
   'user', '', 'table', 'Items', 'column', 'ItemBrandID'
go

execute sp_addextendedproperty 'MS_Description', 
   '毛重',
   'user', '', 'table', 'Items', 'column', 'GrossWgt'
go

execute sp_addextendedproperty 'MS_Description', 
   '净重',
   'user', '', 'table', 'Items', 'column', 'NetWgt'
go

execute sp_addextendedproperty 'MS_Description', 
   '长',
   'user', '', 'table', 'Items', 'column', 'Length'
go

execute sp_addextendedproperty 'MS_Description', 
   '宽',
   'user', '', 'table', 'Items', 'column', 'Width'
go

execute sp_addextendedproperty 'MS_Description', 
   '高',
   'user', '', 'table', 'Items', 'column', 'Height'
go

execute sp_addextendedproperty 'MS_Description', 
   '体积',
   'user', '', 'table', 'Items', 'column', 'Cube'
go

execute sp_addextendedproperty 'MS_Description', 
   '单位',
   'user', '', 'table', 'Items', 'column', 'UomID'
go

execute sp_addextendedproperty 'MS_Description', 
   '所属区域',
   'user', '', 'table', 'Items', 'column', 'AreaID'
go

execute sp_addextendedproperty 'MS_Description', 
   '成本价',
   'user', '', 'table', 'Items', 'column', 'CostPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '市场价',
   'user', '', 'table', 'Items', 'column', 'MarketPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '建议售价',
   'user', '', 'table', 'Items', 'column', 'AdvicePrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '本店售价',
   'user', '', 'table', 'Items', 'column', 'SalesPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '款',
   'user', '', 'table', 'Items', 'column', 'ItemStyle'
go

execute sp_addextendedproperty 'MS_Description', 
   '色',
   'user', '', 'table', 'Items', 'column', 'ItemColor'
go

execute sp_addextendedproperty 'MS_Description', 
   '码',
   'user', '', 'table', 'Items', 'column', 'ItemSize'
go

execute sp_addextendedproperty 'MS_Description', 
   '购买1件赠送的积分',
   'user', '', 'table', 'Items', 'column', 'PresentPoints'
go

execute sp_addextendedproperty 'MS_Description', 
   '首页显示图片',
   'user', '', 'table', 'Items', 'column', 'PhotoUrl'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', '', 'table', 'Items', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否启用',
   'user', '', 'table', 'Items', 'column', 'IsActive'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否审核通过',
   'user', '', 'table', 'Items', 'column', 'IsAudited'
go

execute sp_addextendedproperty 'MS_Description', 
   '计费方式',
   'user', '', 'table', 'Items', 'column', 'BillingType'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', '', 'table', 'Items', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', '', 'table', 'Items', 'column', 'CreatedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新人',
   'user', '', 'table', 'Items', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新时间',
   'user', '', 'table', 'Items', 'column', 'UpdatedDate'
go

/*==============================================================*/
/* Table: MemberComment                                         */
/*==============================================================*/
create table dbo.MemberComment (
   CommentID            int                  identity,
   ItemID               int                  not null,
   Title                nvarchar(50)         null,
   Content              nvarchar(500)        null,
   CommentPoints        int                  null,
   IsActive             nvarchar(1)          null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_MEMBERCOMMENT primary key (CommentID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '会员评价表
   会员用户对已消费商品的评价',
   'user', 'dbo', 'table', 'MemberComment'
go

execute sp_addextendedproperty 'MS_Description', 
   '评价ID',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'CommentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品ID',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'ItemID'
go

execute sp_addextendedproperty 'MS_Description', 
   '标题',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'Title'
go

execute sp_addextendedproperty 'MS_Description', 
   '内容',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'Content'
go

execute sp_addextendedproperty 'MS_Description', 
   '评价获得积分',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'CommentPoints'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否启用',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'IsActive'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'CreatedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新人',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新日期',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'UpdatedDate'
go

/*==============================================================*/
/* Table: MemberLevel                                           */
/*==============================================================*/
create table dbo.MemberLevel (
   ID                   int                  identity,
   LevelCode            nvarchar(20)         not null,
   LevelName            nvarchar(30)         not null,
   Remark               nvarchar(50)         null,
   IsActive             nvarchar(1)          null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_MEMBERLEVEL primary key (ID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '维护会员等级',
   'user', 'dbo', 'table', 'MemberLevel'
go

execute sp_addextendedproperty 'MS_Description', 
   '自增主键',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '等级代码',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'LevelCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '等级名称',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'LevelName'
go

execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否启用',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'IsActive'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'CreatedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新人',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新时间',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'UpdatedDate'
go

/*==============================================================*/
/* Table: MemberOrder                                           */
/*==============================================================*/
create table dbo.MemberOrder (
   OrderID              int                  identity,
   OrderDate            datetime             not null,
   MemberID             nvarchar(20)         null,
   PayMethod            nvarchar(20)         null,
   Ticket               nvarchar(30)         null,
   TotalAmount          decimal(22,7)        null,
   TotalItemCount       int                  null,
   Status               nvarchar(20)         null,
   Contact              nvarchar(20)         null,
   ContactPhone         nvarchar(30)         null,
   ContactAddress       nvarchar(100)        null,
   Ts                   timestamp            null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_MEMBERORDER primary key (OrderID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '会员订单表
   一个会员的一张订单可能会买多个供应商的商品
   提交订单的时候会拆分给供应商订单（VendorOrders）',
   'user', 'dbo', 'table', 'MemberOrder'
go

execute sp_addextendedproperty 'MS_Description', 
   '订单号自增主键',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'OrderID'
go

execute sp_addextendedproperty 'MS_Description', 
   '订单日期',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'OrderDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '会员号',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'MemberID'
go

execute sp_addextendedproperty 'MS_Description', 
   '付款方式',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'PayMethod'
go

execute sp_addextendedproperty 'MS_Description', 
   '优惠卷号码',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'Ticket'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品总价值',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'TotalAmount'
go

execute sp_addextendedproperty 'MS_Description', 
   '商品总数量',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'TotalItemCount'
go

execute sp_addextendedproperty 'MS_Description', 
   '订单状态',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'Status'
go

execute sp_addextendedproperty 'MS_Description', 
   '联系人',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'Contact'
go

execute sp_addextendedproperty 'MS_Description', 
   '联系电话',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'ContactPhone'
go

execute sp_addextendedproperty 'MS_Description', 
   '联系地址 ',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'ContactAddress'
go

execute sp_addextendedproperty 'MS_Description', 
   '时间',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'Ts'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'CreatedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新人',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新时间',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'UpdatedDate'
go

/*==============================================================*/
/* Table: MemberOrderDetail                                     */
/*==============================================================*/
create table dbo.MemberOrderDetail (
   DetailID             int                  identity,
   OrderID              int                  not null,
   ItemID               int                  not null,
   Qty                  int                  not null,
   Price                decimal(22,7)        null,
   Status               nvarchar(20)         null,
   Ts                   timestamp            null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_MEMBERORDERDETAIL primary key (DetailID)
)
go

/*==============================================================*/
/* Table: Members                                               */
/*==============================================================*/
create table dbo.Members (
   MemberID             int                  identity,
   MemberCode           nvarchar(50)         not null,
   MemberName           nvarchar(50)         not null,
   LoginPwd             nvarchar(30)         null,
   PayPwd               nvarchar(30)         null,
   MemberLevel          nvarchar(10)         null,
   Sex                  nvarchar(10)         null,
   Birthday             datetime             null,
   Age                  int                  null,
   Minority             nvarchar(10)         null,
   Trades               nvarchar(30)         null,
   HomeAddress          nvarchar(100)        null,
   PostCode             nvarchar(10)         null,
   Email                nvarchar(50)         not null,
   OfficePhone          nvarchar(30)         null,
   MobilePhone          nvarchar(30)         not null,
   HomePhone            nvarchar(30)         null,
   Fax                  nvarchar(30)         null,
   QQ                   nvarchar(30)         null,
   Msn                  nvarchar(30)         null,
   PwdQuestion          nvarchar(100)        null,
   PwdAnswer            nvarchar(100)        null,
   RegisterDate         datetime             null,
   LastLoginIP          nvarchar(20)         null,
   LoginCount           int                  null,
   LastLoginTime        datetime             null,
   PreDeposits          decimal(22,7)        null,
   Points               int                  null,
   HoldPreDeposits      decimal(22,7)        null,
   HoldPoints           int                  null,
   TotalConsumeMoney    decimal(22,7)        null,
   TotalTransCount      int                  null,
   IsActive             nvarchar(1)          null,
   CretaedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_MEMBERS primary key (MemberID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '会员表（终端消息者）',
   'user', 'dbo', 'table', 'Members'
go

execute sp_addextendedproperty 'MS_Description', 
   '用户名',
   'user', 'dbo', 'table', 'Members', 'column', 'MemberCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '真实姓名',
   'user', 'dbo', 'table', 'Members', 'column', 'MemberName'
go

execute sp_addextendedproperty 'MS_Description', 
   '登录密码',
   'user', 'dbo', 'table', 'Members', 'column', 'LoginPwd'
go

execute sp_addextendedproperty 'MS_Description', 
   '支付密码',
   'user', 'dbo', 'table', 'Members', 'column', 'PayPwd'
go

execute sp_addextendedproperty 'MS_Description', 
   '会员等级',
   'user', 'dbo', 'table', 'Members', 'column', 'MemberLevel'
go

execute sp_addextendedproperty 'MS_Description', 
   '性别',
   'user', 'dbo', 'table', 'Members', 'column', 'Sex'
go

execute sp_addextendedproperty 'MS_Description', 
   '生日',
   'user', 'dbo', 'table', 'Members', 'column', 'Birthday'
go

execute sp_addextendedproperty 'MS_Description', 
   '年龄',
   'user', 'dbo', 'table', 'Members', 'column', 'Age'
go

execute sp_addextendedproperty 'MS_Description', 
   '民族',
   'user', 'dbo', 'table', 'Members', 'column', 'Minority'
go

execute sp_addextendedproperty 'MS_Description', 
   '从事行业',
   'user', 'dbo', 'table', 'Members', 'column', 'Trades'
go

execute sp_addextendedproperty 'MS_Description', 
   '家庭住址',
   'user', 'dbo', 'table', 'Members', 'column', 'HomeAddress'
go

execute sp_addextendedproperty 'MS_Description', 
   '邮政编码',
   'user', 'dbo', 'table', 'Members', 'column', 'PostCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '电子邮件',
   'user', 'dbo', 'table', 'Members', 'column', 'Email'
go

execute sp_addextendedproperty 'MS_Description', 
   '办公室电话',
   'user', 'dbo', 'table', 'Members', 'column', 'OfficePhone'
go

execute sp_addextendedproperty 'MS_Description', 
   '移动电话',
   'user', 'dbo', 'table', 'Members', 'column', 'MobilePhone'
go

execute sp_addextendedproperty 'MS_Description', 
   '家庭电话',
   'user', 'dbo', 'table', 'Members', 'column', 'HomePhone'
go

execute sp_addextendedproperty 'MS_Description', 
   '传真',
   'user', 'dbo', 'table', 'Members', 'column', 'Fax'
go

execute sp_addextendedproperty 'MS_Description', 
   '密码找回问题',
   'user', 'dbo', 'table', 'Members', 'column', 'PwdQuestion'
go

execute sp_addextendedproperty 'MS_Description', 
   '密码找回答案',
   'user', 'dbo', 'table', 'Members', 'column', 'PwdAnswer'
go

execute sp_addextendedproperty 'MS_Description', 
   '注册日期',
   'user', 'dbo', 'table', 'Members', 'column', 'RegisterDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '上次登录IP',
   'user', 'dbo', 'table', 'Members', 'column', 'LastLoginIP'
go

execute sp_addextendedproperty 'MS_Description', 
   '登录次数',
   'user', 'dbo', 'table', 'Members', 'column', 'LoginCount'
go

execute sp_addextendedproperty 'MS_Description', 
   '上次登录时间',
   'user', 'dbo', 'table', 'Members', 'column', 'LastLoginTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '当前预存款',
   'user', 'dbo', 'table', 'Members', 'column', 'PreDeposits'
go

execute sp_addextendedproperty 'MS_Description', 
   '当前积分',
   'user', 'dbo', 'table', 'Members', 'column', 'Points'
go

execute sp_addextendedproperty 'MS_Description', 
   '冻结预存款',
   'user', 'dbo', 'table', 'Members', 'column', 'HoldPreDeposits'
go

execute sp_addextendedproperty 'MS_Description', 
   '冻结积分',
   'user', 'dbo', 'table', 'Members', 'column', 'HoldPoints'
go

execute sp_addextendedproperty 'MS_Description', 
   '总消费金额 ',
   'user', 'dbo', 'table', 'Members', 'column', 'TotalConsumeMoney'
go

execute sp_addextendedproperty 'MS_Description', 
   '总交易量',
   'user', 'dbo', 'table', 'Members', 'column', 'TotalTransCount'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否启用',
   'user', 'dbo', 'table', 'Members', 'column', 'IsActive'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', 'dbo', 'table', 'Members', 'column', 'CretaedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'Members', 'column', 'CreatedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新人',
   'user', 'dbo', 'table', 'Members', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新日期',
   'user', 'dbo', 'table', 'Members', 'column', 'UpdatedDate'
go

/*==============================================================*/
/* Table: PurchaseOrder                                         */
/*==============================================================*/
create table dbo.PurchaseOrder (
   PoID                 int                  identity,
   SupplierID           int                  not null,
   PoDate               datetime             not null,
   Contact              nvarchar(20)         null,
   ContactPhone         nvarchar(30)         null,
   ContactAddress       nvarchar(100)        null,
   Status               nvarchar(20)         null,
   TotalAmount          decimal(22,7)        null,
   TotalItemCount       int                  null,
   Remark               nvarchar(100)        null,
   Ts                   timestamp            null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_PURCHASEORDER primary key (PoID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '采购订单
   供应商的采购订单',
   'user', 'dbo', 'table', 'PurchaseOrder'
go

/*==============================================================*/
/* Table: PurchaseOrderDetail                                   */
/*==============================================================*/
create table dbo.PurchaseOrderDetail (
   DetailID             int                  identity,
   PoID                 int                  not null,
   ItemID               int                  not null,
   Qty                  int                  not null,
   Price                decimal(22,7)        null,
   Status               nvarchar(20)         null,
   Remark               nvarchar(100)        null,
   Ts                   timestamp            null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_PURCHASEORDERDETAIL primary key (DetailID)
)
go

/*==============================================================*/
/* Table: RoleFunction                                          */
/*==============================================================*/
create table dbo.RoleFunction (
   RoleID               int                  not null,
   FunctionID           int                  not null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   constraint PK_ROLEFUNCTION primary key (RoleID,FunctionID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '角色权限表',
   'user', 'dbo', 'table', 'RoleFunction'
go

/*==============================================================*/
/* Table: Roles                                                 */
/*==============================================================*/
create table dbo.Roles (
   RoleID               int                  identity,
   RoleName             nvarchar(20)         not null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_ROLES primary key (RoleID)
)
go

/*==============================================================*/
/* Table: SalesOrder                                            */
/*==============================================================*/
create table dbo.SalesOrder (
   SoID                 int                  identity,
   MemberID             int                  not null,
   SoDate               datetime             not null,
   SupplierID           int                  not null,
   Status               nvarchar(20)         null,
   TotalAmount          decimal(22,7)        null,
   TotalItemCount       int                  null,
   Contact              nvarchar(20)         null,
   ContactPhone         nvarchar(30)         null,
   ContactAddress       nvarchar(100)        null,
   PayMethod            nvarchar(20)         null,
   Ts                   timestamp            null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_SALESORDER primary key (SoID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '供应商销售订单',
   'user', 'dbo', 'table', 'SalesOrder'
go

/*==============================================================*/
/* Table: SalesOrderDetail                                      */
/*==============================================================*/
create table dbo.SalesOrderDetail (
   DetailID             int                  identity,
   SoID                 int                  not null,
   ItemID               int                  not null,
   Qty                  int                  not null,
   Price                decimal(22,7)        not null,
   TotalAmount          decimal(22,7)        null,
   Remark               nvarchar(100)        null,
   Ts                   timestamp            null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_SALESORDERDETAIL primary key (DetailID)
)
go

/*==============================================================*/
/* Table: Suppliers                                             */
/*==============================================================*/
create table dbo.Suppliers (
   SupplierID           int                  identity,
   SupplierCode         nvarchar(30)         not null,
   SupplierName         nvarchar(50)         not null,
   LoginPwd             nvarchar(30)         null,
   Email                nvarchar(50)         null,
   ContactAddress       nvarchar(100)        null,
   Contact              nvarchar(30)         null,
   Region               nvarchar(30)         null,
   Stage                nvarchar(30)         null,
   PostCode             nvarchar(10)         null,
   ContactPhone         nvarchar(30)         null,
   MobilePhone          nvarchar(30)         null,
   QQ                   nvarchar(30)         null,
   Msn                  nvarchar(30)         null,
   Fax                  nvarchar(30)         null,
   WebUrl               nvarchar(60)         null,
   Logo                 nvarchar(30)         null,
   CompanyIntro         nvarchar(300)        null,
   CompanyCulture       nvarchar(300)        null,
   ArtificialPerson     nvarchar(30)         null,
   Remark               nvarchar(300)        null,
   IsActive             nvarchar(1)          null,
   CretaedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_SUPPLIERS primary key (SupplierID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '供应商
   新增供应商的同时新增一条User记录，User代码和供应商代码相同',
   'user', 'dbo', 'table', 'Suppliers'
go

/*==============================================================*/
/* Table: SysCode                                               */
/*==============================================================*/
create table dbo.SysCode (
   CodeID               int                  identity,
   GroupID              nvarchar(50)         not null,
   CodeName             nvarchar(50)         not null,
   SeqNo                int                  null,
   IsActive             nvarchar(1)          null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_SYSCODE primary key (CodeID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '系统代码',
   'user', 'dbo', 'table', 'SysCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '自增主键',
   'user', 'dbo', 'table', 'SysCode', 'column', 'CodeID'
go

execute sp_addextendedproperty 'MS_Description', 
   '分组号',
   'user', 'dbo', 'table', 'SysCode', 'column', 'GroupID'
go

execute sp_addextendedproperty 'MS_Description', 
   '代码名称',
   'user', 'dbo', 'table', 'SysCode', 'column', 'CodeName'
go

execute sp_addextendedproperty 'MS_Description', 
   '显示顺序',
   'user', 'dbo', 'table', 'SysCode', 'column', 'SeqNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '是否启用',
   'user', 'dbo', 'table', 'SysCode', 'column', 'IsActive'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', 'dbo', 'table', 'SysCode', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', 'dbo', 'table', 'SysCode', 'column', 'CreatedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新人',
   'user', 'dbo', 'table', 'SysCode', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '更新日期',
   'user', 'dbo', 'table', 'SysCode', 'column', 'UpdatedDate'
go

/*==============================================================*/
/* Table: SysSetting                                            */
/*==============================================================*/
create table dbo.SysSetting (
   SysSettingID         nvarchar(50)         not null,
   Description          nvarchar(100)        not null,
   Value                nvarchar(50)         not null,
   DefaultValue         nvarchar(50)         null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_SYSSETTING primary key (SysSettingID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '系统设置',
   'user', 'dbo', 'table', 'SysSetting'
go

/*==============================================================*/
/* Table: UserRole                                              */
/*==============================================================*/
create table dbo.UserRole (
   UserID               int                  not null,
   RoleID               int                  not null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null
)
go

/*==============================================================*/
/* Table: UserSupplier                                          */
/*==============================================================*/
create table dbo.UserSupplier (
   UserID               int                  not null,
   SupplierID           int                  not null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   constraint PK_USERSUPPLIER primary key (UserID,SupplierID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '用户供应商权限表
   查询的时候会用到',
   'user', 'dbo', 'table', 'UserSupplier'
go

/*==============================================================*/
/* Table: Users                                                 */
/*==============================================================*/
create table dbo.Users (
   UserID               int                  identity,
   UserCode             nvarchar(30)         not null,
   UserName             nvarchar(30)         not null,
   LoginPwd             nvarchar(30)         null,
   Sex                  nvarchar(10)         null,
   Age                  int                  null,
   Department           nvarchar(20)         null,
   JobNum               nvarchar(20)         null,
   Email                nvarchar(50)         null,
   MobilePhone          nvarchar(30)         null,
   IsActive             nvarchar(1)          null,
   UserGroup            nvarchar(30)         null,
   CreatedBy            nvarchar(20)         null,
   CreatedDate          datetime             null,
   UpdatedBy            nvarchar(20)         null,
   UpdatedDate          datetime             null,
   constraint PK_USERS primary key (UserID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '用户表
   分为系统用户和供应商用户，用一个字段来区分',
   'user', 'dbo', 'table', 'Users'
go
