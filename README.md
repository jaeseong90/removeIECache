# removeIECache Program
스레드가 돌면서 30초마다 인터넷 임시 폴더중 IE 디렉토리의 jpg와 mts 파일을 삭제합니다. dll, 태스크를 사용하면 자꾸화면에 뜨는게 불편해서 만들게 되었습니다.

### 개발 
visual studio
.netframework 4.7.2, c#, winform 

##### ThreadSuspend 
 - Thread.Suspend has been deprecated.  Please use other classes in System.Threading, such as Monitor, Mutex, Event, and Semaphore, 
to synchronize Threads or protect resources.  http://go.microsoft.com/fwlink/?linkid=14202'	

