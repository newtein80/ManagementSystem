#### 1. Project 추가 (Class Library)
- ManagementSystem.Domain
- ManagementSystem.Application
- ManagementSystem.Infra

#### 2. Data, Model 이동
- Migration 폴더 삭제
- Data, Model 폴더 이동
(대상 프로젝트: Infra 프로젝트)
	- Namespace, Using package 수정
	- 필요 패키지 설치
		Microsoft.AspNetCore.ApiAuthorization.IdentityServer
		Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
		Microsoft.AspNetCore.Identity.EntityFrameworkCore
		Microsoft.EntityFrameworkCore.SqlServer
		Microsoft.EntityFrameworkCore.Tools
		Microsoft.EntityFrameworkCore
- Api 프로젝트에 참조 추가
(참조 프로젝트: Infra 프로젝트)
- startup.cs 에 Infra 관련 의존성 추가
- 로그인 의 ApplicationUser 의존성 추가 부분 수정
- Program.cs 수정
- 데이터베이스 생성
(Create_Database.sql 실행, 폴더 확인)
	- `add-migration` 명령어 실행(Identity 모델 관련 테이블 코드 생성 및 초기화)
	- 필수 확인 사항
		- 연결문자열
		(appsettings.json > DefaultConnection)
		- 명령 실행 대상 프로젝트 확인 (기본 프로젝트: ManagementSystem.Infra)
		- add-migration 명령어 실행 위치(경로)
	- `update-database` 명령어 실행(실제 테이블 생성)