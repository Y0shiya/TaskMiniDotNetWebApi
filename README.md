# TaskMiniDotNetWebApi

## API



#### タスク一覧取得

 

リクエスト GET http://エンドポイント/api/tasks

 
 
レスポンス 200 OK http://エンドポイント/tasks

 
	* ヘッダー　Content-Type: application/json
    
 	* ボディ　　[{"id":"d3e42108-7d74-44f6-82e4-0f235a26f745","note":"you can add task or note or remarks.","order":18},...]
    



#### タスク新規登録

  

リクエスト POST http://エンドポイント/api/tasks
  
    
	* ヘッダー　Content-Type: application/json
    
	* ボディ    {"id":"6497c3fa-057a-4536-a4c7-af8922861750","note":"add task.","order":0}
  
  

レスポンス 204 No Content http://エンドポイント/api/tasks
  


#### タスク編集登録

  

リクエスト PUT http://エンドポイント/api/tasks
  
    
	* ヘッダー　Content-Type: application/json
    
	* ボディ    {"id":"cbdf4d0d-f4fa-4ed2-975f-304df2eec022","note":"edit task.","order":23}
    
  

レスポンス 204 No Content http://エンドポイント/api/tasks
  


#### タスク削除

  

リクエスト DELETE http://エンドポイント/api/tasks/{id}
 
 
レスポンス 204 No Content http://エンドポイント/api/tasks/{id}