# TaskMiniDotNetWebApi

## API�d�l

### Task(=�����^�X�N)�S���擾

 
���N�G�X�g GET http://�G���h�|�C���g/api/tasks

  
    
���X�|���X 200 OK http://�G���h�|�C���g/tasks

 
	* �w�b�_�[�@Content-Type: application/json
    
 	* �{�f�B�@�@[{"id":"d3e42108-7d74-44f6-82e4-0f235a26f745","note":"you can add task or note or remarks.","order":18},...]
  

### Task�擾
���N�G�X�g GET http://�G���h�|�C���g/api/tasks/{id} 
    
���X�|���X 200 OK http://�G���h�|�C���g/api/tasks/{id}


	* �w�b�_�[�@Content-Type: application/json

	* �{�f�B�@{"id":"d3e42108-7d74-44f6-82e4-0f235a26f745","note":"get single task","order":18}


### Task�V�K�o�^

  
���N�G�X�g POST http://�G���h�|�C���g/api/tasks
  
    
	* �w�b�_�[�@Content-Type: application/json
    
	* �{�f�B    {"id":"6497c3fa-057a-4536-a4c7-af8922861750","note":"add task.","order":0}
  
  
���X�|���X 204 No Content http://�G���h�|�C���g/api/tasks
  



### Task�ҏW�o�^

  
���N�G�X�g PUT http://�G���h�|�C���g/api/tasks
  
    
	* �w�b�_�[�@Content-Type: application/json
    
	* �{�f�B    {"id":"cbdf4d0d-f4fa-4ed2-975f-304df2eec022","note":"edit task.","order":23}
    
  
���X�|���X 204 No Content http://�G���h�|�C���g/api/tasks
  



### Task�폜

  
���N�G�X�g DELETE http://�G���h�|�C���g/api/tasks/{id}
   
    
���X�|���X 204 No Content http://�G���h�|�C���g/api/tasks/{id}



### Trash(=�����^�X�N)�S���擾
���N�G�X�g GET http://�G���h�|�C���g/api/trash  
    
���X�|���X 200 OK http://�G���h�|�C���g/api/trash  
    
	* �w�b�_�[�@Content-Type: application/json

	* �{�f�B�@[{"id":"fdb72194-6ae9-400e-9723-7542f42fa290","note":"done task.","order":21},...{...}]


### Trash�S���폜
���N�G�X�g DELETE http://�G���h�|�C���g/api/trash  
    
���X�|���X 204 No Content http://�G���h�|�C���g/api/trash


### Trash�폜
���N�G�X�g DELETE http://�G���h�|�C���g/api/trash/{id}  
    
���X�|���X 204 No Content http://�G���h�|�C���g/api/trash/{id}

