﻿using Autofac;
using Autofac.Integration.Mvc;
using Kingime.Net.Core.General;
using Kingime.Net.DataAccess.General;
using Kingime.Net.Entity.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Kingime.Net.MvcApp
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoFacConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            ////第一步： 构造一个AutoFac的builder容器  
            //var builder = new ContainerBuilder();

            ////第二步：告诉AutoFac控制器工厂，控制器类的创建去哪些程序集中查找（默认控制器工厂是去扫描bin目录下的所有程序集）
            ////2.1 从当前运行的bin目录下加载Kingime.Net.MvcApp.dll程序集  
            //var controllerAss = Assembly.Load("Kingime.Net.MvcApp");
            ////2.2 告诉AutoFac控制器工厂，控制器的创建从controllerAss中查找（注意：RegisterControllers()方法是一个可变参数，如果你的控制器类的创建需要去多个程序集中查找的话，那么我们就再用Assembly controllerBss=Assembly.Load("需要的程序集名")加载需要的程序集，然后与controllerAss组成数组，然后将这个数组传递到RegisterControllers()方法中）  
            //builder.RegisterControllers(controllerAss);

            ////第三步：告诉AutoFac容器，创建项目中的指定类的对象实例，以接口的形式存储（其实就是创建数据仓储层与业务逻辑层这两个程序集中所有类的对象实例，然后以其接口的形式保存到AutoFac容器内存中，当然如果有需要也可以创建其他程序集的所有类的对象实例，这个只需要我们指定就可以了）  
            ////3.1 加载数据仓储层Kingime.Net.DataAccess.dll程序集。  
            //var repositoryAss = Assembly.Load("Kingime.Net.DataAccess");
            ////3.2 反射扫描这个FB.CMS.Repository.dll程序集中所有的类，得到这个程序集中所有类的集合。  
            //var repositoryTypes = repositoryAss.GetTypes();
            ////3.3 告诉AutoFac容器，创建rtypes这个集合中所有类的对象实例（指明创建的rtypes这个集合中所有类的对象实例，以其接口的形式保存）
            //builder.RegisterTypes(repositoryTypes).AsImplementedInterfaces();

            ////第四步：创建一个真正的AutoFac的工作容器  
            //var container = builder.Build();
            ////第五步：将当前容器中的控制器工厂替换掉MVC默认的控制器工厂。（即：不要MVC默认的控制器工厂了，用AutoFac容器中的控制器工厂替代）此处使用的是将AutoFac工作容器交给MVC底层 (需要using System.Web.Mvc;)  
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //第一步： 构造一个AutoFac的builder容器  
            var builder = new ContainerBuilder();

            //第二步：告诉AutoFac控制器工厂，控制器类的创建去哪些程序集中查找（默认控制器工厂是去扫描bin目录下的所有程序集）
            //2.1 从当前运行的bin目录下加载Kingime.Net.MvcApp.dll程序集  
            var controllerAss = Assembly.Load("Kingime.Net.MvcApp");
            //2.2 告诉AutoFac控制器工厂，控制器的创建从controllerAss中查找（注意：RegisterControllers()方法是一个可变参数，如果你的控制器类的创建需要去多个程序集中查找的话，那么我们就再用Assembly controllerBss=Assembly.Load("需要的程序集名")加载需要的程序集，然后与controllerAss组成数组，然后将这个数组传递到RegisterControllers()方法中）  
            builder.RegisterControllers(controllerAss);

            //builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>));

            var dependencyType = typeof(IDependency);
            var repositoryAss = Assembly.Load("Kingime.Net.DataAccess");
            var assemblies = new Assembly[] { repositoryAss };
            builder.RegisterAssemblyTypes(assemblies).Where(type => dependencyType.IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerLifetimeScope();

            //第四步：创建一个真正的AutoFac的工作容器
            IContainer container = builder.Build();

            //第五步：将当前容器中的控制器工厂替换掉MVC默认的控制器工厂。（即：不要MVC默认的控制器工厂了，用AutoFac容器中的控制器工厂替代）此处使用的是将AutoFac工作容器交给MVC底层 (需要using System.Web.Mvc;)  
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}