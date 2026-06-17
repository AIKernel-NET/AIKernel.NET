---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Index"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
lang: ja
title: "Migration Documentation Index"
description: "AIKernel の contract と ecosystem 変更に関する互換性維持型 migration notes の索引です。"
---

# Migration Documentation Index

## 目的

このディレクトリは、AIKernel の contract と ecosystem の変更について、互換性を維持しながら進めるための migration notes を記録します。
各文書は、既存の公開 API、DTO、enum、contract、gate logic を壊さないことを前提に、変更範囲と移行方針を明示します。

## 文書

- [Concept Elevation Refactoring Migration Notes](concept-elevation-v0.1.1.1-jp.md)

## 方針

Migration documents には、少なくとも次の項目を記載します。

- compatibility policy
- old API から new surface への対応
- non-goals
- affected repositories
- test and documentation requirements

この索引は公開ドキュメント向けの入口です。詳細な作業メモが必要な場合でも、公開面では互換性、非変更範囲、検証条件を先に示します。
