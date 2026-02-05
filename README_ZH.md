<!--

    Licensed to the Apache Software Foundation (ASF) under one
    or more contributor license agreements.  See the NOTICE file
    distributed with this work for additional information
    regarding copyright ownership.  The ASF licenses this file
    to you under the Apache License, Version 2.0 (the
    "License"); you may not use this file except in compliance
    with the License.  You may obtain a copy of the License at
    
        http://www.apache.org/licenses/LICENSE-2.0
    
    Unless required by applicable law or agreed to in writing,
    software distributed under the License is distributed on an
    "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
    KIND, either express or implied.  See the License for the
    specific language governing permissions and limitations
    under the License.

-->
[English](./README.md) | [中文](./README_ZH.md)

# Apache IoTDB C#语言客户端
[![E2E Tests](https://github.com/apache/iotdb-client-csharp/actions/workflows/e2e.yml/badge.svg)](https://github.com/apache/iotdb-client-csharp/actions/workflows/e2e.yml)
[![License](https://img.shields.io/badge/license-Apache%202-4EB1BA.svg)](https://www.apache.org/licenses/LICENSE-2.0.html)
![NuGet Version](https://img.shields.io/nuget/v/Apache.IoTDB)
![NuGet Downloads](https://img.shields.io/nuget/dt/Apache.IoTDB)

## 概览

本仓库是Apache IoTDB的C#语言客户端,与其他语言支持相同语义的用户接口。

Apache IoTDB website: https://iotdb.apache.org

Apache IoTDB Github: https://github.com/apache/iotdb

## 如何安装
### 从NuGet Package安装

我们为CSharp用户准备了NuGet包，用户可直接通过.NET CLI进行客户端安装，[NuGet包链接如下](https://www.nuget.org/packages/Apache.IoTDB/),命令行中运行如下命令即可完成安装

我们为 C# 用户准备了一个 Nuget 包。用户可以直接通过 .NET CLI 进行客户端安装。命令行中运行如下命令即可完成安装
    
```sh
dotnet add package Apache.IoTDB
```

详情请访问 [NuGet 上的包](https://www.nuget.org/packages/Apache.IoTDB/)。


> [!NOTE]
> 请注意，`Apache.IoTDB`这个包仅支持大于`.net framework 4.6.1`的版本。

## 环境准备

    .NET SDK Version >= 5.0
    .NET Framework >= 4.6.1 

## 如何使用 (快速上手)
用户可以通过参考Apache-IoTDB-Client-CSharp-UserCase目录下的用例快速入门。这些用例提供了客户端的基本功能和用法的参考。

对于希望深入了解客户端用法并探索更高级特性的用户，samples目录包含了额外的代码示例。

## 功能特性

### SessionPool异常处理和健康监控

C#客户端为SessionPool操作提供了全面的异常处理和健康监控功能:

- **SessionPoolDepletedException（会话池耗尽异常）**: 当池无法提供客户端连接时，提供详细信息的专用异常，包括：
  - 耗尽原因（超时、重连失败等）
  - 可用客户端数量
  - 总池大小
  - 重连失败次数

- **健康指标**: 通过属性实时监控池状态：
  - `AvailableClients`: 当前可用的客户端数量
  - `TotalPoolSize`: 配置的最大池大小
  - `FailedReconnections`: 重连失败的累计次数

有关异常处理、监控和恢复策略的详细信息，请参阅 [SessionPool异常处理指南](./docs/SessionPool_Exception_Handling.md)。


## iotdb-client-csharp的开发者环境要求

```
.NET SDK Version >= 5.0
.NET Framework >= 4.6.1
ApacheThrift >= 0.14.1
NLog >= 4.7.9
```

### 操作系统

* Linux、MacOS 或其他类 Unix 系统
* Windows + Bash (WSL、cygwin、Git Bash)

### 命令行工具

* dotnet CLI
* Thrift

## 在 nuget.org 上发布你自己的客户端
你可以在这个[文档](./PUBLISH.md)中找到如何发布