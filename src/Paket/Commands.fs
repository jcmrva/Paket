﻿module Paket.Commands

open Nessos.UnionArgParser

type AddArgs =
    | [<First>][<CustomCommandLine("nuget")>][<Mandatory>] Nuget of string
    | [<CustomCommandLine("version")>] Version of string
    | [<AltCommandLine("-f")>] Force
    | [<AltCommandLine("-i")>] Interactive
    | Hard
    | No_Install
with 
    interface IArgParserTemplate with
        member __.Usage = ""

type ConfigArgs = 
    | [<CustomCommandLine("add-credentials")>] AddCredentials of string
with 
    interface IArgParserTemplate with
        member __.Usage = ""

type ConvertFromNugetArgs =
    | [<AltCommandLine("-f")>] Force
    | No_Install
    | No_Auto_Restore
    | Creds_Migration of string
with 
    interface IArgParserTemplate with
        member __.Usage = ""

type FindRefsArgs =
    | [<Rest>][<CustomCommandLine("nuget")>][<Mandatory>] Packages of string
with 
    interface IArgParserTemplate with
        member __.Usage = ""

type InitArgs =
    | [<Hidden>] NoArg
with 
    interface IArgParserTemplate with
        member __.Usage = ""

type InitAutoRestoreArgs =
    | [<Hidden>] NoArg
with 
    interface IArgParserTemplate with
        member __.Usage = ""

type InstallArgs =
    | [<AltCommandLine("-f")>] Force
    | Hard
    | Redirects
with 
    interface IArgParserTemplate with
        member __.Usage = ""

type OutdatedArgs =
    | Ignore_Constraints
    | [<AltCommandLine("--pre")>] Include_Prereleases
with 
    interface IArgParserTemplate with
        member __.Usage = ""

type RemoveArgs =
    | [<First>][<CustomCommandLine("nuget")>][<Mandatory>] Nuget of string
    | [<AltCommandLine("-f")>] Force
    | [<AltCommandLine("-i")>] Interactive
    | Hard
    | No_Install
with 
    interface IArgParserTemplate with
        member __.Usage = ""

type RestoreArgs =
    | [<AltCommandLine("-f")>] Force
    | [<Rest>] References_Files of string
with 
    interface IArgParserTemplate with
        member __.Usage = ""

type SimplifyArgs =
    | [<AltCommandLine("-i")>] Interactive
with 
    interface IArgParserTemplate with
        member __.Usage = ""

type UpdateArgs =
    | [<First>][<CustomCommandLine("nuget")>] Nuget of string
    | [<CustomCommandLine("version")>] Version of string
    | [<AltCommandLine("-f")>] Force
    | Hard
    | Redirects
with 
    interface IArgParserTemplate with
        member __.Usage = ""