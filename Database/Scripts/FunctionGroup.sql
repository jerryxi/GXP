SELECT * FROM OperationLog
  
select * from dbo.FunctionGroup

--DELETE FROM dbo.FunctionGroup

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1100, '1000', 'SystemMgt', 1000, 1, NULL, NULL, 'SystemMgt', 'Y', 'ϵͳ����', NULL, NULL, NULL, NULL);

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1110, '1100', 'PlatformSetting', 1110, 2, '/PlatformSetting/Index', '1110', 'PlatformSetting', 'Y', 'ƽ̨����', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1120, '1100', 'UserInfo', 1120, 2, '/UserInfo/Index', '1120', 'UserInfo', 'Y', '�û�����', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1130, '1100', 'SysCode', 1130, 2, '/SysCode/Index', '1130', 'SysCode', 'Y', 'ϵͳ����', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1140, '1100', 'Roles', 1140, 2, '/Roles/Index', '1140', 'Roles', 'Y', '��ɫ����', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1150, '1100', 'RoleFunction', 1150, 2, '/RoleFunction/Index', '1150', 'RoleFunction', 'Y', '��ɫȨ��', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (1160, '1100', 'UserRole', 1160, 2, '/UserRole/Index', '1160', 'UserRole', 'Y', '�û���ɫ', NULL, NULL, NULL, NULL);



INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (2100, '1000', 'BackgroundMgt', 2000, 1, NULL, NULL, 'BackgroundMgt', 'Y', '��̨����', NULL, NULL, NULL, NULL);

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (2110, '2100', 'AuditItem', 2110, 2, '/AuditItem/Index', '2110', 'AuditItem', 'Y', '�����Ʒ', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (2120, '2100', 'AuditItemComment', 2120, 2, '/AuditItemComment/Index', '2120', 'AuditItemComment', 'Y', '�����Ʒ����', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (2130, '2100', 'IncomeReport', 2130, 2, '/IncomeReport/Index', '2130', 'IncomeReport', 'Y', '���뱨��', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (2140, '2100', 'GradeSetting', 2140, 2, '/GradeSetting/Index', '2140', 'GradeSetting', 'Y', '��������', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (2150, '2100', 'GradeExchangeRule', 2150, 2, '/GradeExchangeRule/Index', '2150', 'GradeExchangeRule', 'Y', '���ֶһ�����', NULL, NULL, NULL, NULL);



INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (3100, '1000', 'MemberMgt', 3000, 1, NULL, NULL, 'MemberMgt', 'Y', '��Ա����', NULL, NULL, NULL, NULL);

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (3110, '3100', 'Member', 3110, 2, '/Member/Index', '3110', 'Members', 'Y', '��Ա�б�', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (3120, '3100', 'MemberLevel', 3120, 2, '/MemberLevel/Index', '3120', 'MemberLevel', 'Y', '��Ա�ȼ�', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (3130, '3100', 'MemberOrder', 3130, 2, '/MemberOrder/Index', '3130', 'MemberOrder', 'Y', '��Ա���� ', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (3140, '3100', 'MemberComment', 3140, 2, '/MemberComment/Index', '3140', 'MemberComment', 'Y', '��Ա����', NULL, NULL, NULL, NULL);

--DELETE FROM FunctionGroup WHERE ParentID='4100'

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4100, '1000', 'SupplierMgt', 4000, 1, NULL, NULL, 'SupplierMgt', 'Y', '�̻�����', NULL, NULL, NULL, NULL);

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4110, '4100', 'Supplier', 4110, 2, '/Supplier/Index', '4110', 'Supplier', 'Y', '�̻��б�', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4120, '4100', 'PurchaseOrder', 4120, 2, '/PurchaseOrder/Index', '4120', 'PurchaseOrder', 'Y', '�ɹ�����', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4130, '4100', 'ItemInventory', 4130, 2, '/ItemInventory/Index', '4130', 'ItemInventory', 'Y', '��Ʒ��� ', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4140, '4100', 'SalesOrder', 4140, 2, '/SalesOrder/Index', '4140', 'SalesOrder', 'Y', '���۶���', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4150, '4100', 'PublishItem', 4150, 2, '/PublishItem/Index', '4150', 'PublishItem', 'Y', '������Ʒ', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4160, '4100', 'InOutReport', 4160, 2, '/InOutReport/Index', '4160', 'InOutReport', 'Y', '�����汨��', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4170, '4100', 'SalesReport', 4170, 2, '/SalesReport/Index', '4170', 'SalesReport', 'Y', '���۱���', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (4180, '4100', 'FinanceReport', 4180, 2, '/FinanceReport/Index', '4180', 'FinanceReport', 'Y', '���񱨱�', NULL, NULL, NULL, NULL);


UPDATE FunctionGroup SET UDF01='��Ʒ����' WHERE FunctionID='5100' AND ParentID='1000'

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5100, '1000', 'ItemMgt', 5000, 1, NULL, NULL, 'ItemMgt', 'Y', '��Ʒ����', NULL, NULL, NULL, NULL);

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5110, '5100', 'ItemBrand', 5110, 2, '/ItemBrand/Index', '5110', 'ItemBrand', 'Y', '��ƷƷ��', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5120, '5100', 'ItemClassify', 5120, 2, '/ItemClassify/Index', '5120', 'ItemClassify', 'Y', '��Ʒ����', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5130, '5100', 'Item', 5130, 2, '/Item/Index', '5130', 'Item', 'Y', '��Ʒ�б� ', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5140, '5100', 'ItemProperty', 5140, 2, '/ItemProperty/Index', '5140', 'ItemProperty', 'Y', '��Ʒ����', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5150, '5100', 'ItemType', 5150, 2, '/ItemType/Index', '5150', 'ItemType', 'Y', '��Ʒ����', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5160, '5100', 'ItemComment', 5160, 2, '/ItemComment/Index', '5160', 'ItemComment', 'Y', '��Ʒ����', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5170, '5100', 'ItemFeedback', 5170, 2, '/ItemFeedback/Index', '5170', 'ItemFeedback', 'Y', '��Ʒ��ѯ', NULL, NULL, NULL, NULL);
INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (5180, '5100', 'Area', 5180, 2, '/Area/Index', '5180', 'Area', 'Y', '�������', NULL, NULL, NULL, NULL);



INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (6100, '1000', 'MessageMgt', 6000, 1, NULL, NULL, 'MessageMgt', 'Y', '��Ϣ����', NULL, NULL, NULL, NULL);

INSERT INTO dbo.FunctionGroup (FunctionID, ParentID, FunctionName, SeqNo, GroupLevel, Url, PageID, PageName, IsActive, UDF01, UDF02, UDF03, UDF04, UDF05)
VALUES (6110, '6100', 'MessageCenter', 6110, 2, '/MessageCenter/Index', '5110', 'MessageCenter', 'Y', '��Ϣ����', NULL, NULL, NULL, NULL);














