﻿module Paket.SemVerSpecs

open Paket
open NUnit.Framework
open FsUnit

[<Test>]
let ``can parse semver strings and print the result``() = 
    (SemVer.Parse "0.1.2").ToString() |> shouldEqual "0.1.2"
    (SemVer.Parse "1.0.2").ToString() |> shouldEqual "1.0.2"
    (SemVer.Parse "1.0").ToString() |> shouldEqual "1.0"
    (SemVer.Parse "1.0.0-alpha.1").ToString() |> shouldEqual "1.0.0-alpha.1"
    (SemVer.Parse "1.0.0-beta.2").ToString() |> shouldEqual "1.0.0-beta.2"
    (SemVer.Parse "1.0.0-alpha.beta").ToString() |> shouldEqual "1.0.0-alpha.beta"
    (SemVer.Parse "1.0.0-rc.1").ToString() |> shouldEqual "1.0.0-rc.1"
    (SemVer.Parse "1.2.3-foo").ToString() |> shouldEqual "1.2.3-foo"

[<Test>]
let ``can parse semver strings``() = 
    let semVer = SemVer.Parse("1.2.3-alpha.beta")
    semVer.Major |> shouldEqual 1
    semVer.Minor |> shouldEqual 2
    semVer.Patch |> shouldEqual 3
    semVer.PreRelease |> shouldEqual (Some { Origin = "alpha"
                                             Name = "alpha"
                                             Number = None })
    semVer.Build |> shouldEqual "beta"

[<Test>]
let ``can compare semvers``() =
    (SemVer.Parse "1.2.3") |> shouldEqual (SemVer.Parse "1.2.3")
    (SemVer.Parse "1.0.0-rc.3") |> shouldBeGreaterThan (SemVer.Parse "1.0.0-rc.1")
    (SemVer.Parse "1.0.0-alpha.3") |> shouldBeGreaterThan (SemVer.Parse "1.0.0-alpha.2")
    (SemVer.Parse "1.2.3-alpha.3") |> shouldEqual (SemVer.Parse "1.2.3-alpha.3")
    (SemVer.Parse "1.0.0-alpha") |> shouldBeSmallerThan (SemVer.Parse "1.0.0-alpha.1")
    (SemVer.Parse "1.0.0-alpha.1") |> shouldBeSmallerThan (SemVer.Parse "1.0.0-alpha.beta")
    (SemVer.Parse "1.0.0-alpha.beta") |> shouldBeSmallerThan (SemVer.Parse "1.0.0-beta")
    (SemVer.Parse "1.0.0-beta") |> shouldBeSmallerThan (SemVer.Parse "1.0.0-beta.2")
    (SemVer.Parse "1.0.0-beta.2") |> shouldBeSmallerThan (SemVer.Parse "1.0.0-beta.11")
    (SemVer.Parse "1.0.0-beta.11") |> shouldBeSmallerThan (SemVer.Parse "1.0.0-rc.1")
    (SemVer.Parse "1.0.0-rc.1") |> shouldBeSmallerThan (SemVer.Parse "1.0.0")
    (SemVer.Parse "2.3.4") |> shouldBeGreaterThan (SemVer.Parse "2.3.4-alpha")
    (SemVer.Parse "1.5.0-rc.1") |> shouldBeGreaterThan (SemVer.Parse "1.5.0-beta.2")
    (SemVer.Parse "2.3.4-alpha2") |> shouldBeGreaterThan (SemVer.Parse "2.3.4-alpha")
    (SemVer.Parse "2.3.4-alpha003") |> shouldBeGreaterThan (SemVer.Parse "2.3.4-alpha2")
    (SemVer.Parse "2.3.4-rc") |> shouldBeGreaterThan (SemVer.Parse "2.3.4-beta2")

[<Test>]
let ``can compare 4-parts semvers``() =
    (SemVer.Parse "1.0.0.2420") |> shouldBeGreaterThan (SemVer.Parse "1.0")

[<Test>]
let ``trailing zeros are equal``() =
    (SemVer.Parse "1.0.0") |> shouldEqual (SemVer.Parse "1.0")
    (SemVer.Parse "1.0.0") |> shouldEqual (SemVer.Parse "1")
    (SemVer.Parse "1.2.3.0") |> shouldEqual (SemVer.Parse "1.2.3")
    (SemVer.Parse "1.2.0") |> shouldEqual (SemVer.Parse "1.2")

[<Test>]
let ``can parse strange versions``() = 
    (SemVer.Parse "2.1-alpha10").ToString() |> shouldEqual "2.1-alpha10"
    (SemVer.Parse "2-alpha100").ToString() |> shouldEqual "2-alpha100"

[<Test>]
let ``can parse FSHarp.Data versions``() = 
    (SemVer.Parse "2.1.0-beta3").ToString() |> shouldEqual "2.1.0-beta3"
    
