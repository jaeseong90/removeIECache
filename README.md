# 세정POS KCP연동 에이전트

### 셋팅
- .netframework 4.7.2

##### ThreadSuspend 
 - Thread.Suspend has been deprecated.  Please use other classes in System.Threading, such as Monitor, Mutex, Event, and Semaphore, 
to synchronize Threads or protect resources.  http://go.microsoft.com/fwlink/?linkid=14202'	

##### 배포
 - 파일경로 사용
 - 게시버전 서버버전확인 필수
 - 설치폴더 http://pos.sejung.co.kr/download/kcpmodule/
 - 서명 sejung pfx 확인
 - 타임스탬프 서버 http://timestamp.digicert.com/
 - ClickOnec보안설정
 - 32비트 기본사용
 - 플랫폼 대상 Any CPU