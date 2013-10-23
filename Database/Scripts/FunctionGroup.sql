SELECT * FROM OperationLog
  
select * from dbo.FunctionGroup

--DELETE FROM dbo.FunctionGroup

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1100, '1000', 'SystemMgt', 1000, 1, NULL, NULL, 'SystemMgt', 'Y', '系统管理', NULL, NULL, NULL, NULL);

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1110, '1100', 'PlatformSetting', 1110, 2, '/PlatformSetting/Index', '1110', 'PlatformSetting', 'Y', '平台设置', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1120, '1100', 'UserInfo', 1120, 2, '/UserInfo/Index', '1120', 'UserInfo', 'Y', '用户管理', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1130, '1100', 'SysCode', 1130, 2, '/SysCode/Index', '1130', 'SysCode', 'Y', '系统代码', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1140, '1100', 'Roles', 1140, 2, '/Roles/Index', '1140', 'Roles', 'Y', '角色管理', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1150, '1100', 'RoleFunction', 1150, 2, '/RoleFunction/Index', '1150', 'RoleFunction', 'Y', '角色权限', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1160, '1100', 'UserRole', 1160, 2, '/UserRole/Index', '1160', 'UserRole', 'Y', '用户角色', NULL, NULL, NULL, NULL);



INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (2100, '1000', 'BackgroundMgt', 2000, 1, NULL, NULL, 'BackgroundMgt', 'Y', '后台管理', NULL, NULL, NULL, NULL);

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (2110, '2100', 'AuditItem', 2110, 2, '/AuditItem/Index', '2110', 'AuditItem', 'Y', '审核商品', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (2120, '2100', 'AuditItemComment', 2120, 2, '/AuditItemComment/Index', '2120', 'AuditItemComment', 'Y', '审核商品评价', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (2130, '2100', 'IncomeReport', 2130, 2, '/IncomeReport/Index', '2130', 'IncomeReport', 'Y', '收入报告', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (2140, '2100', 'GradeSetting', 2140, 2, '/GradeSetting/Index', '2140', 'GradeSetting', 'Y', '积分设置', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (2150, '2100', 'GradeExchangeRule', 2150, 2, '/GradeExchangeRule/Index', '2150', 'GradeExchangeRule', 'Y', '积分兑换规则', NULL, NULL, NULL, NULL);



INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (3100, '1000', 'MemberMgt', 3000, 1, NULL, NULL, 'MemberMgt', 'Y', '会员管理', NULL, NULL, NULL, NULL);

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (3110, '3100', 'Member', 3110, 2, '/Member/Index', '3110', 'Members', 'Y', '会员列表', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (3120, '3100', 'MemberLevel', 3120, 2, '/MemberLevel/Index', '3120', 'MemberLevel', 'Y', '会员等级', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (3130, '3100', 'MemberOrder', 3130, 2, '/MemberOrder/Index', '3130', 'MemberOrder', 'Y', '会员订单 ', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (3140, '3100', 'MemberComment', 3140, 2, '/MemberComment/Index', '3140', 'MemberComment', 'Y', '会员评价', NULL, NULL, NULL, NULL);

--DELETE FROM FunctionGroup WHERE ParentID='4100'

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4100, '1000', 'SupplierMgt', 4000, 1, NULL, NULL, 'SupplierMgt', 'Y', '商户管理', NULL, NULL, NULL, NULL);

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4110, '4100', 'Supplier', 4110, 2, '/Supplier/Index', '4110', 'Supplier', 'Y', '商户列表', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4120, '4100', 'PurchaseOrder', 4120, 2, '/PurchaseOrder/Index', '4120', 'PurchaseOrder', 'Y', '采购订单', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4130, '4100', 'ItemInventory', 4130, 2, '/ItemInventory/Index', '4130', 'ItemInventory', 'Y', '商品库存 ', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4140, '4100', 'SalesOrder', 4140, 2, '/SalesOrder/Index', '4140', 'SalesOrder', 'Y', '销售订单', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4150, '4100', 'PublishItem', 4150, 2, '/PublishItem/Index', '4150', 'PublishItem', 'Y', '发布商品', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4160, '4100', 'InOutReport', 4160, 2, '/InOutReport/Index', '4160', 'InOutReport', 'Y', '进销存报表', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4170, '4100', 'SalesReport', 4170, 2, '/SalesReport/Index', '4170', 'SalesReport', 'Y', '销售报表', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4180, '4100', 'FinanceReport', 4180, 2, '/FinanceReport/Index', '4180', 'FinanceReport', 'Y', '财务报表', NULL, NULL, NULL, NULL);


UPDATE FunctionGroup SET UDF01='商品管理' WHERE FunctionID='5100' AND ParentID='1000'

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5100, '1000', 'ItemMgt', 5000, 1, NULL, NULL, 'ItemMgt', 'Y', '商品管理', NULL, NULL, NULL, NULL);

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5110, '5100', 'ItemBrand', 5110, 2, '/ItemBrand/Index', '5110', 'ItemBrand', 'Y', '商品品牌', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5120, '5100', 'ItemClassify', 5120, 2, '/ItemClassify/Index', '5120', 'ItemClassify', 'Y', '商品分类', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5130, '5100', 'Item', 5130, 2, '/Item/Index', '5130', 'Item', 'Y', '商品列表 ', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5140, '5100', 'ItemProperty', 5140, 2, '/ItemProperty/Index', '5140', 'ItemProperty', 'Y', '商品属性', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5150, '5100', 'ItemType', 5150, 2, '/ItemType/Index', '5150', 'ItemType', 'Y', '商品类型', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5160, '5100', 'ItemComment', 5160, 2, '/ItemComment/Index', '5160', 'ItemComment', 'Y', '商品评价', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5170, '5100', 'ItemFeedback', 5170, 2, '/ItemFeedback/Index', '5170', 'ItemFeedback', 'Y', '商品咨询', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5180, '5100', 'Area', 5180, 2, '/Area/Index', '5180', 'Area', 'Y', '区域管理', NULL, NULL, NULL, NULL);



INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (6100, '1000', 'MessageMgt', 6000, 1, NULL, NULL, 'MessageMgt', 'Y', '消息中心', NULL, NULL, NULL, NULL);

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (6110, '6100', 'MessageCenter', 6110, 2, '/MessageCenter/Index', '5110', 'MessageCenter', 'Y', '消息中心', NULL, NULL, NULL, NULL);














