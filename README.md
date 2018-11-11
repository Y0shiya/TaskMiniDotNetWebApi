# TaskMiniDotNetWebApi

## API仕様

### Task(=未完タスク)全件取得

 
リクエスト GET http://エンドポイント/api/tasks

  
    
レスポンス 200 OK http://エンドポイント/tasks

 
	* ヘッダー　Content-Type: application/json
    
 	* ボディ　　[{"id":"d3e42108-7d74-44f6-82e4-0f235a26f745","note":"you can add task or note or remarks.","order":18},...]
  

### Task取得
リクエスト GET http://エンドポイント/api/tasks/{id} 
    
レスポンス 200 OK http://エンドポイント/api/tasks/{id}


	* ヘッダー　Content-Type: application/json

	* ボディ　{"id":"d3e42108-7d74-44f6-82e4-0f235a26f745","note":"get single task","order":18}


### Task新規登録

  
リクエスト POST http://エンドポイント/api/tasks
  
    
	* ヘッダー　Content-Type: application/json
    
	* ボディ    {"id":"6497c3fa-057a-4536-a4c7-af8922861750","note":"add task.","order":0}
  
  
レスポンス 204 No Content http://エンドポイント/api/tasks
  



### Task編集登録

  
リクエスト PUT http://エンドポイント/api/tasks
  
    
	* ヘッダー　Content-Type: application/json
    
	* ボディ    {"id":"cbdf4d0d-f4fa-4ed2-975f-304df2eec022","note":"edit task.","order":23}
    
  
レスポンス 204 No Content http://エンドポイント/api/tasks
  



### Task削除

  
リクエスト DELETE http://エンドポイント/api/tasks/{id}
   
    
レスポンス 204 No Content http://エンドポイント/api/tasks/{id}



### Trash(=完了タスク)全件取得
リクエスト GET http://エンドポイント/api/trash  
    
レスポンス 200 OK http://エンドポイント/api/trash  
    
	* ヘッダー　Content-Type: application/json

	* ボディ　[{"id":"fdb72194-6ae9-400e-9723-7542f42fa290","note":"done task.","order":21},...{...}]


### Trash全件削除
リクエスト DELETE http://エンドポイント/api/trash  
    
レスポンス 204 No Content http://エンドポイント/api/trash


### Trash削除
リクエスト DELETE http://エンドポイント/api/trash/{id}  
    
レスポンス 204 No Content http://エンドポイント/api/trash/{id}

