一、题目
	基于Mysql、.NET Framework的超市数据管理系统。
二、需求分析
	在现代化生活之中，超市已经成为人们生活之中密不可分的一个场所，随着经济的发展，生活水平的提高，超市日常的销售记录变得尤为庞大，过去传统的通过人工来管理大型的超市销售和经营在当今市场上尤为吃力，因此需要通过数据库系统来管理超市中巨大的数据信息。同时，目前来说，网络已经遍及生活的每一处，人们开始习惯于利用网络来购物，因此，本次系统设计一个适合超市管理员来管理超市信息以及便于用户购买的数据库管理简易系统。
 ![在这里插入图片描述](https://img-blog.csdnimg.cn/2020123112224916.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2xoMjAxOGk=,size_16,color_FFFFFF,t_70)

图  1 需求图
	本系统的需求如上图所示，具体分析如下：
	采购商品：超市日常的采购、进货商品
	订单管理：对采购商品的订单进行管理
	商品管理：超市进货商品的库存量、日期等信息管理
	销售管理：超市日常销售记录管理
	购买商品：用户利用该系统进行购买商品
	用户管理：对使用该系统的非管理员用户进行信息管理
	用户充值：用户账号余额充值
对应的数据结构分析如下：
数据结构名	含义说明	组成
商品	记录商品的基本信息	商品号、商品名、单价、库存量、供应商
用户	记录用户给个人信息	用户账号、用户名、密码、年龄、余额
管理员	记录管理员个人信息	管理员账号、管理员名、密码、年龄
销售记录	记录销售情况信息	流水号、商品号、销售价、日期
购买记录	记录用户购买信息	流水号、商品号、商品名、商品价、日期
订单	记录采购信息	订单号、订单价、供应商、日期、商品号

三、系统设计（包括数据库的概念结构设计、逻辑结构设计等）
 	数据库概念结构设计
通过对实际生活的需求分析处理，得到对应的E-R图如下：
 ![在这里插入图片描述](https://img-blog.csdnimg.cn/20201231122312905.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2xoMjAxOGk=,size_16,color_FFFFFF,t_70)

图  2 超市系统数据库概念结构E-R图
![在这里插入图片描述](https://img-blog.csdnimg.cn/20201231122808737.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2xoMjAxOGk=,size_16,color_FFFFFF,t_70)

 	数据库逻辑结构设计
将数据库概念结构E-R模型进行向逻辑结构转换，对应结果如下：
	 Admin表
管理员(管理员账号,管理员姓名，管理员密码，管理员年龄)
表结构如图 所示
 ![在这里插入图片描述](https://img-blog.csdnimg.cn/20201231122349459.png)


图  3 Admin表结构
	Buyrecode表
购买记录表(购买记录号，商品号，商品价格，购买日期)
表结构如图4所示
![在这里插入图片描述](https://img-blog.csdnimg.cn/2020123112240063.png)
 
图  4 Buyrecode表结构
	Goods表
商品表(商品号，商品名，商品价格，商品库存，供应商)
表结构如图5所示
 ![在这里插入图片描述](https://img-blog.csdnimg.cn/20201231122407302.png)

图  5 goods表结构
	Orders表
订单表(订单号，订单价格，供应商，日期，商品号)
表结构如图6所示
 ![在这里插入图片描述](https://img-blog.csdnimg.cn/20201231122419439.png)

图  6 orders表结构
	Sale表
销售表(流水号、商品号、商品名、销售价、日期)
表结构如图6所示
 ![在这里插入图片描述](https://img-blog.csdnimg.cn/20201231122443362.png)

图  7 sale表结构
	User表
用户表(用户号、用户名、用户密码、用户年龄、余额) 表结构如下：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20201231122450399.png)
 
图  8 user表结构
 	数据库安全性设计
1.	用户身份鉴别方式
超市管理数据库系统使用静态口令的方式进行鉴别，其中静态口令保存在用户信息中。虽然静态口令的安全性较低，但是一种常用且简单的身份鉴别方式。
2.	存取控制
超市管理系统通过自主存取控制，其中分为两类用户，其中普通用户只能对商品表、购买记录表、个人用户表、和销售记录表进行添加、修改操作，而管理员用户则是享有所有表的存取控制权限。
3.	视图机制
超市管理系统对普通用户使用视图机制，将部分无需向用户呈现的数据进行隐藏。如在用户购物之中和购买记录中的数据是从数据视图中获取。

四、系统实现（包括数据库管理系统、开发平台与工具、开发语言等）

 	数据库管理系统实现
利用Mysql语句按照上述数据库分析的逻辑结构分别创建对应的表和字段，并设置对应的实体完整性和参照完整性。
 	超市管理系统实现
1)	数据库连接
创建一个dao类和daouser类分别为普通用户和管理员用户连接数据库，其中dao类连接通过数据库的root用户访问数据库，而daouser类通过创建数据库user用户访问数据库。其中在设计数据库连接时，利用MySqlConnection类进行连接数据库，MysqlCmomandSQL代表Mysql语句，DataReader代表读取数据库数据，Excute()进行Mysql语句执行，Dao类具体设计代码如下：

```csharp
01 class Dao
02 {   MySqlConnection conn;
03     public MySqlConnection connect()
04     {   string connStr = "server = localhost; user = root; database = market; port = 
05         3306; password = 1234";
06         conn = new MySqlConnection(connStr);
07         try
08         {   conn.Open();
09         }
10         catch (Exception ex)
11         {   Console.WriteLine(ex.ToString());
12         }
13         return conn;
14     }
15     public MySqlCommand command(string sql)
16     {   MySqlCommand cmd = new MySqlCommand(sql, connect());
17         return cmd;
18     }
19     public int Execute(string sql)
20     {   return command(sql).ExecuteNonQuery();
21     }
22     public MySqlDataReader read(string sql)
23     {   return command(sql).ExecuteReader();
24     }
25     public void Daoclose()
26     {   conn.Close();
27     }
28 
29 }
```

2)	前端窗口设计
超市管理系统基于.NET Framework进行开发，通过窗口拖动相关控件对前端窗口进行设计布局，如在读取超市管理系统的销售记录时，通过DataGridView控件从数据库读取数据进行显示，利用label、button、文本框等控件对相关的业务功能(如数据修改、数据查询、数据删除和增加数据等功能)进行实现，其中在销售记录管理中使用日期控件控制记录，从而对当前日期的销售记录查询和简单统计。
3)	对应逻辑功能实现
系统中的主要逻辑功能有：数据查询、增加数据、删除数据、修改数据以及统计数据五大功能，对应的功能实现分别如下：

```sql
01 DialogResult dr = MessageBox.Show("确认修改该用户" +"？", "信息提示", MessageBoxButtons.OKCancel, 
02                   MessageBoxIcon.Question);
03 if (dr == DialogResult.OK) {
04     Dao dao = new Dao();
05     string sql = $"update user set uid='{uid}', uname='{uname }',upsw= '{upsw}', uage='{uage}',balance= '{blance}')";
06                  //数据库执行对应的语句
07     int n = dao.Execute(sql);
08     if (n > 0) {
09         MessageBox.Show("修改成功!");
10     } else {
11         MessageBox.Show("修改失败");
12     }
13 }
```
对于数据的增删查改和统计显示五个功能，基本的执行框架都是一致的，相应代码如上所示，不同的是数据库Mysql的执行语句不一样，因此修改对应的Mysql语句即可，对应语句如下(以用户管理功能为例)：
	数据查询：string sql = $"select * from user where uid ='{textBox1.Text}' or uname ='{textBox1.Text}'";//textBox1.Text即输入框条件
	增加数据：string sql = $"insert into user values('{uid}', '{uname }', '{upsw}', '{uage}', '{blance}')";
	删除数据：string sql = $"delete from user where uid='{uid}'";
	修改数据：string sql = $"update user set uid='{uid}', uname='{uname }',upsw= '{upsw}', uage='{uage}',balance= '{blance}')";//数据库执行对应的语句
	统计数据(以销售记录统计为例)：
string sql = $"select sum(sprice) from sale where date like '%{year}%'";
string sql1 = $"select sum(sprice) from sale where date like '%{year}-{month}%'";
string sql2 = $"select sum(sprice) from sale where date like '%{year}-{month}-{Day}%'";
 	开发平台与工具
本系统基于Windows平台开发，使用Navicat Premium、Visual Studio 2019、Mysql8.0开发工具进行开发。
 	开发语言
本系统数据库开发语言：Mysql.
本系统功能开发语言：C#.

五、使用说明
超市管理系统使用说明
本系统平台用户初始登录用户名：user密码：user.管理员用户名：admin,管理员密码：admin.
	软件初始界面为登录界面，输入用户名或管理员用户名分别进入用户界面和管理员界面。其中用户界面有主窗口显示用户个人信息，菜单栏有：购买商品、购买记录、账号充值、退出等选项。分别实现以下功能：
	购买商品：用户可利用此功能进行查询商品、购买商品。
	购买记录：用户可利用此功能查询自己的购买历史记录。
	账号充值：用户可利用此功能来对自己账户余额进行充值。
	退出：退出用户界面。
	而管理员界面菜单栏有商品管理、用户管理、订单管理、销售管理以及退出选项，分别实现以下功能:
	商品管理：管理员通过此功能进行商品的增加、修改、删除、查询等功能。
	用户管理：管理员通过此功能进行普通用户账号信息的增加、修改、删除、查询等功能。
	订单管理：管理员通过此功能进行与供应商订单信息的增加、修改、删除、查询等功能。
	销售管理：管理员可通过此功能进行销售记录的查询、时间内销售额的统计分析等功能。
	退出：退出管理员界面。


