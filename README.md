# EFCoreDemo
1,DbFirst:  通过数据库更新代码的命令   
Scaffold-DbContext "数据库连接语句" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models - Force  
PS：自己并没有实现这个命令，在执行的过程中遇到各种问题。  

2，CodeFirst  
 （1）先定义好实体以及DbContext。  
 （2）Add-Migration 名称   
 （3）update-database  
 
3，实体状态  
   一般如果只是查询一个实体而不做任何更新或者删除操作的话，建议加上AsNotracking  
   
4，导航属性懒加载的实现方式  
   在demo中我主要使用了Include的方式来实现懒加载  
   
5，DDD的充血模型和EFCore结合的浅显展示，需要在IEntityTypeConfiguration中定义
 
