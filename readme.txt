目录含义
========

src\: 源代码
============
src\KMS\: VS 2008sp1格式的项目文件
src\Dependencies\: 项目依赖的所有第三方组件DLL

说明：由于使用了ASP.NET MVC库，开发环境使用VS2008 SP1，.NET库版本是3.5 SP1，建议下载整合的更新包，其中包括了VS 2008 SP1以及.NET 3.5 SP1。
更新包地址：http://www.microsoft.com/downloads/details.aspx?displaylang=en&FamilyID=27673c47-b3b5-4c67-bd99-84e525b5ce61

doc\: 项目开发文档（如需求说明书等）
===================================

reference\: 参考文档（如Nhibernate参考文档等）
=============================================


tools\: 辅助开发工具
====================
tools\db2hbm\: Database To HibernateMapping, Nhibernate数据库模式到映射文件自动生成工具
tools\hbm2net-1.0.0.2-alpha\: HibernateMapping To .NET Class, NHibernate映射文件到实体类自动生成工具

说明：为使用方便，建议将db2hbm以及hbm2net工具的可执行文件，加入到系统环境变量Path中。