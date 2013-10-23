
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
   '����',
   'user', 'dbo', 'table', 'Area'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'Area', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', 'dbo', 'table', 'Area', 'column', 'AreaCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'Area', 'column', 'AreaName'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�����',
   'user', 'dbo', 'table', 'Area', 'column', 'IsActive'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', 'dbo', 'table', 'Area', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'Area', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'Area', 'column', 'CretaedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'Area', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
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
   '�ڵ�',
   'user', '', 'table', 'FunctionGroup', 'column', 'FunctionID'
go

execute sp_addextendedproperty 'MS_Description', 
   '���ڵ�',
   'user', '', 'table', 'FunctionGroup', 'column', 'ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ڵ�����',
   'user', '', 'table', 'FunctionGroup', 'column', 'FunctionName'
go

execute sp_addextendedproperty 'MS_Description', 
   '˳��',
   'user', '', 'table', 'FunctionGroup', 'column', 'SeqNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '�㼶����',
   'user', '', 'table', 'FunctionGroup', 'column', 'GroupLevel'
go

execute sp_addextendedproperty 'MS_Description', 
   'ҳ������',
   'user', '', 'table', 'FunctionGroup', 'column', 'Url'
go

execute sp_addextendedproperty 'MS_Description', 
   'ҳ�����',
   'user', '', 'table', 'FunctionGroup', 'column', 'PageID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ҳ������',
   'user', '', 'table', 'FunctionGroup', 'column', 'PageName'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ť����',
   'user', '', 'table', 'FunctionGroup', 'column', 'ButtonID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ť����',
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
   '��Ʒ��潻�ױ�
   ��Ʒ�Ľ�����Ҫ��¼һ�����ף����ں��ڸ��ٺͱ���',
   'user', @CmtInvTransaction, 'table', 'InvTransaction'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', '', 'table', 'InvTransaction', 'column', 'TransID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����',
   'user', '', 'table', 'InvTransaction', 'column', 'ItemID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ӧ�̴���',
   'user', '', 'table', 'InvTransaction', 'column', 'SupplierID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', '', 'table', 'InvTransaction', 'column', 'TransType'
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', '', 'table', 'InvTransaction', 'column', 'Qty'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ɹ�������',
   'user', '', 'table', 'InvTransaction', 'column', 'PoID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ɹ������к�',
   'user', '', 'table', 'InvTransaction', 'column', 'PoLineID'
go

execute sp_addextendedproperty 'MS_Description', 
   '���۶�����',
   'user', '', 'table', 'InvTransaction', 'column', 'SoID'
go

execute sp_addextendedproperty 'MS_Description', 
   '���۶����к�',
   'user', '', 'table', 'InvTransaction', 'column', 'SoLineID'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', '', 'table', 'InvTransaction', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
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
   '��Ӧ����Ʒ����',
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
   '��ƷƷ��',
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
   '��Ʒ����',
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
   '��Ʒ��ѯ����',
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
   '��Ʒ����',
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
   '��Ʒ��
   ��Ӧ�� �� ��Ʒ����  Ϊ����',
   'user', @CmtItems, 'table', 'Items'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', '', 'table', 'Items', 'column', 'ItemID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ӧ�̴���',
   'user', '', 'table', 'Items', 'column', 'SupplierID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����',
   'user', '', 'table', 'Items', 'column', 'ItemCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����',
   'user', '', 'table', 'Items', 'column', 'ItemName'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����',
   'user', '', 'table', 'Items', 'column', 'ItemDescription'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ���',
   'user', '', 'table', 'Items', 'column', 'ItemSynopsis'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ���ʣ���ʵ����Ʒ��������Ʒ',
   'user', '', 'table', 'Items', 'column', 'ItemCharacter'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����',
   'user', '', 'table', 'Items', 'column', 'ItemClassID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ƷƷ��',
   'user', '', 'table', 'Items', 'column', 'ItemBrandID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ë��',
   'user', '', 'table', 'Items', 'column', 'GrossWgt'
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', '', 'table', 'Items', 'column', 'NetWgt'
go

execute sp_addextendedproperty 'MS_Description', 
   '��',
   'user', '', 'table', 'Items', 'column', 'Length'
go

execute sp_addextendedproperty 'MS_Description', 
   '��',
   'user', '', 'table', 'Items', 'column', 'Width'
go

execute sp_addextendedproperty 'MS_Description', 
   '��',
   'user', '', 'table', 'Items', 'column', 'Height'
go

execute sp_addextendedproperty 'MS_Description', 
   '���',
   'user', '', 'table', 'Items', 'column', 'Cube'
go

execute sp_addextendedproperty 'MS_Description', 
   '��λ',
   'user', '', 'table', 'Items', 'column', 'UomID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', '', 'table', 'Items', 'column', 'AreaID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ɱ���',
   'user', '', 'table', 'Items', 'column', 'CostPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '�г���',
   'user', '', 'table', 'Items', 'column', 'MarketPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '�����ۼ�',
   'user', '', 'table', 'Items', 'column', 'AdvicePrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '�����ۼ�',
   'user', '', 'table', 'Items', 'column', 'SalesPrice'
go

execute sp_addextendedproperty 'MS_Description', 
   '��',
   'user', '', 'table', 'Items', 'column', 'ItemStyle'
go

execute sp_addextendedproperty 'MS_Description', 
   'ɫ',
   'user', '', 'table', 'Items', 'column', 'ItemColor'
go

execute sp_addextendedproperty 'MS_Description', 
   '��',
   'user', '', 'table', 'Items', 'column', 'ItemSize'
go

execute sp_addextendedproperty 'MS_Description', 
   '����1�����͵Ļ���',
   'user', '', 'table', 'Items', 'column', 'PresentPoints'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ҳ��ʾͼƬ',
   'user', '', 'table', 'Items', 'column', 'PhotoUrl'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', '', 'table', 'Items', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�����',
   'user', '', 'table', 'Items', 'column', 'IsActive'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ����ͨ��',
   'user', '', 'table', 'Items', 'column', 'IsAudited'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Ʒѷ�ʽ',
   'user', '', 'table', 'Items', 'column', 'BillingType'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', '', 'table', 'Items', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', '', 'table', 'Items', 'column', 'CreatedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', '', 'table', 'Items', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
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
   '��Ա���۱�
   ��Ա�û�����������Ʒ������',
   'user', 'dbo', 'table', 'MemberComment'
go

execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'CommentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ƷID',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'ItemID'
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'Title'
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'Content'
go

execute sp_addextendedproperty 'MS_Description', 
   '���ۻ�û���',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'CommentPoints'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�����',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'IsActive'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'CreatedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'MemberComment', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
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
   'ά����Ա�ȼ�',
   'user', 'dbo', 'table', 'MemberLevel'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ȼ�����',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'LevelCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ȼ�����',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'LevelName'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�����',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'IsActive'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'CreatedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'MemberLevel', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
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
   '��Ա������
   һ����Ա��һ�Ŷ������ܻ�������Ӧ�̵���Ʒ
   �ύ������ʱ����ָ���Ӧ�̶�����VendorOrders��',
   'user', 'dbo', 'table', 'MemberOrder'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������������',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'OrderID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'OrderDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ա��',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'MemberID'
go

execute sp_addextendedproperty 'MS_Description', 
   '���ʽ',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'PayMethod'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Żݾ����',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'Ticket'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ�ܼ�ֵ',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'TotalAmount'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ������',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'TotalItemCount'
go

execute sp_addextendedproperty 'MS_Description', 
   '����״̬',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'Status'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ϵ��',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'Contact'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ϵ�绰',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'ContactPhone'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ϵ��ַ ',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'ContactAddress'
go

execute sp_addextendedproperty 'MS_Description', 
   'ʱ��',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'Ts'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'CreatedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'MemberOrder', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
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
   '��Ա���ն���Ϣ�ߣ�',
   'user', 'dbo', 'table', 'Members'
go

execute sp_addextendedproperty 'MS_Description', 
   '�û���',
   'user', 'dbo', 'table', 'Members', 'column', 'MemberCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ʵ����',
   'user', 'dbo', 'table', 'Members', 'column', 'MemberName'
go

execute sp_addextendedproperty 'MS_Description', 
   '��¼����',
   'user', 'dbo', 'table', 'Members', 'column', 'LoginPwd'
go

execute sp_addextendedproperty 'MS_Description', 
   '֧������',
   'user', 'dbo', 'table', 'Members', 'column', 'PayPwd'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ա�ȼ�',
   'user', 'dbo', 'table', 'Members', 'column', 'MemberLevel'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Ա�',
   'user', 'dbo', 'table', 'Members', 'column', 'Sex'
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'Members', 'column', 'Birthday'
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'Members', 'column', 'Age'
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'Members', 'column', 'Minority'
go

execute sp_addextendedproperty 'MS_Description', 
   '������ҵ',
   'user', 'dbo', 'table', 'Members', 'column', 'Trades'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ͥסַ',
   'user', 'dbo', 'table', 'Members', 'column', 'HomeAddress'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'Members', 'column', 'PostCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '�����ʼ�',
   'user', 'dbo', 'table', 'Members', 'column', 'Email'
go

execute sp_addextendedproperty 'MS_Description', 
   '�칫�ҵ绰',
   'user', 'dbo', 'table', 'Members', 'column', 'OfficePhone'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ƶ��绰',
   'user', 'dbo', 'table', 'Members', 'column', 'MobilePhone'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ͥ�绰',
   'user', 'dbo', 'table', 'Members', 'column', 'HomePhone'
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'Members', 'column', 'Fax'
go

execute sp_addextendedproperty 'MS_Description', 
   '�����һ�����',
   'user', 'dbo', 'table', 'Members', 'column', 'PwdQuestion'
go

execute sp_addextendedproperty 'MS_Description', 
   '�����һش�',
   'user', 'dbo', 'table', 'Members', 'column', 'PwdAnswer'
go

execute sp_addextendedproperty 'MS_Description', 
   'ע������',
   'user', 'dbo', 'table', 'Members', 'column', 'RegisterDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ϴε�¼IP',
   'user', 'dbo', 'table', 'Members', 'column', 'LastLoginIP'
go

execute sp_addextendedproperty 'MS_Description', 
   '��¼����',
   'user', 'dbo', 'table', 'Members', 'column', 'LoginCount'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ϴε�¼ʱ��',
   'user', 'dbo', 'table', 'Members', 'column', 'LastLoginTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ǰԤ���',
   'user', 'dbo', 'table', 'Members', 'column', 'PreDeposits'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ǰ����',
   'user', 'dbo', 'table', 'Members', 'column', 'Points'
go

execute sp_addextendedproperty 'MS_Description', 
   '����Ԥ���',
   'user', 'dbo', 'table', 'Members', 'column', 'HoldPreDeposits'
go

execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', 'dbo', 'table', 'Members', 'column', 'HoldPoints'
go

execute sp_addextendedproperty 'MS_Description', 
   '�����ѽ�� ',
   'user', 'dbo', 'table', 'Members', 'column', 'TotalConsumeMoney'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ܽ�����',
   'user', 'dbo', 'table', 'Members', 'column', 'TotalTransCount'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�����',
   'user', 'dbo', 'table', 'Members', 'column', 'IsActive'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'Members', 'column', 'CretaedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'Members', 'column', 'CreatedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'Members', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
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
   '�ɹ�����
   ��Ӧ�̵Ĳɹ�����',
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
   '��ɫȨ�ޱ�',
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
   '��Ӧ�����۶���',
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
   '��Ӧ��
   ������Ӧ�̵�ͬʱ����һ��User��¼��User����͹�Ӧ�̴�����ͬ',
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
   'ϵͳ����',
   'user', 'dbo', 'table', 'SysCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'SysCode', 'column', 'CodeID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�����',
   'user', 'dbo', 'table', 'SysCode', 'column', 'GroupID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'SysCode', 'column', 'CodeName'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ʾ˳��',
   'user', 'dbo', 'table', 'SysCode', 'column', 'SeqNo'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�����',
   'user', 'dbo', 'table', 'SysCode', 'column', 'IsActive'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'SysCode', 'column', 'CreatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'SysCode', 'column', 'CreatedDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', 'dbo', 'table', 'SysCode', 'column', 'UpdatedBy'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
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
   'ϵͳ����',
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
   '�û���Ӧ��Ȩ�ޱ�
   ��ѯ��ʱ����õ�',
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
   '�û���
   ��Ϊϵͳ�û��͹�Ӧ���û�����һ���ֶ�������',
   'user', 'dbo', 'table', 'Users'
go
