# APSNET_Gourmet_group_buying
asp.net基于三层模式多商家美食团购网毕业源码案例设计
## 开发技术：基于MVC思想和三层设计模式，前台采用bootstrap响应式框架，后台div+css
## 开发软件: Visual Studio 2010以上    数据库：sqlserver2005以上

1.浏览美食
2.订购美食
3.查询自己的记录
4.参与美食的评价
5.收藏美食
根据区域查询美食，以成都为案例
6.个人信息的设置
(2)商家有如下特点。
1.发布商品
2.查看商品评论
3查看商品销量

用户: 用户名,登录密码,姓名,性别,出生日期,用户照片,联系电话,邮箱,所在区域,家庭地址,注册时间

商家: 商家用户名,登录密码,商家名称,商家照片,商家介绍,成立日期,商家电话,商家邮箱,所在区域,商家地址,注册时间

区域: 区域id,区域名称

商品类别: 类别id,类别名称,类别描述

商品: 商品id,商品类别,商品名称,商品主图,商品价格,商品库存,商品描述,发布的商家,发布时间

商品评论: 评论id,被评商品,评论内容,评论用户,评论时间

订单: 订单编号,订购商品,订购数量,订购单价,订购总价,支付方式,订单状态,收货人,收货人电话,收货人地址,订单备注,下单时间,下单用户

商品收藏: 收藏id,被收藏商品,收藏用户,收藏时间

订单状态: 订单状态id,订单状态名称
