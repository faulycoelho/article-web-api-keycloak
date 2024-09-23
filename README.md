
Clone this repository and run the docker-compose:

```docker-compose up```

You should now be able to access the Keycloak UI at http://localhost:8888/
![image](https://github.com/user-attachments/assets/c0b51ec6-c956-4cb6-aae9-3a23138a2ff7)

Here I won't detail how to configure keycloak but you can read how to do it in detail on my article: [MEDIUM .NET Web API with Keycloak](https://medium.com/@faulycoelho/net-web-api-with-keycloak-11e0286240b9)

call without token:
```curl --location 'https://localhost:7282/api/Values/get-admin'```

![image](https://github.com/user-attachments/assets/b5845fac-1974-4b13-9506-2ba2d394ffdf)

So, you should generate a new token:

```
curl --location 'https://localhost:7282/api/Auth/login' \
 --header 'Content-Type: application/json' \
 --data '{
 "username": "user-admin",
 "password": "123"
}'
```

![image](https://github.com/user-attachments/assets/3a1dce2d-3388-4e14-bb03-8ca03b0f639b)

After that, you can use the token to call the ValuesController again:
```
curl --location 'https://localhost:7282/api/Values/get-admin' \
--header 'Authorization: Bearer eyJhbGciOiJSUzI1NiIsInR5cCIgOiAiSldUIiwia2lkIiA6ICJMUjZleGppLXJKWnZrVE9PNkRvWTBhNGdlYkNiLUxRY0RJaWhtYnVYQnlZIn0.eyJleHAiOjE3MjY5NTgzOTksImlhdCI6MTcyNjk1ODA5OSwianRpIjoiNzZkMTRlMGEtY2E1Ni00NmJiLWEyZTgtZDU2Y2JiM2E4NmRkIiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo4ODg4L3JlYWxtcy9teS1yZWFsbSIsImF1ZCI6ImFjY291bnQiLCJzdWIiOiI1NzRjM2QwNC0yOGZiLTQ0N2ItODA3YS05YjhkY2U4MjkzZDciLCJ0eXAiOiJCZWFyZXIiLCJhenAiOiJteS1jbGllbnQiLCJzZXNzaW9uX3N0YXRlIjoiYzA5MTQ1YTQtODgxNS00ZGJlLWE0Y2MtOTA0Y2YxOTM0Y2ExIiwiYWNyIjoiMSIsImFsbG93ZWQtb3JpZ2lucyI6WyJodHRwczovL2xvY2FsaG9zdDo3MjgyIl0sInJlYWxtX2FjY2VzcyI6eyJyb2xlcyI6WyJvZmZsaW5lX2FjY2VzcyIsInVtYV9hdXRob3JpemF0aW9uIiwiZGVmYXVsdC1yb2xlcy1teS1yZWFsbSJdfSwicmVzb3VyY2VfYWNjZXNzIjp7Im15LWNsaWVudCI6eyJyb2xlcyI6WyJhZG1pbiJdfSwiYWNjb3VudCI6eyJyb2xlcyI6WyJtYW5hZ2UtYWNjb3VudCIsIm1hbmFnZS1hY2NvdW50LWxpbmtzIiwidmlldy1wcm9maWxlIl19fSwic2NvcGUiOiJlbWFpbCBwcm9maWxlIiwic2lkIjoiYzA5MTQ1YTQtODgxNS00ZGJlLWE0Y2MtOTA0Y2YxOTM0Y2ExIiwiZW1haWxfdmVyaWZpZWQiOnRydWUsInJvbGVzIjpbImFkbWluIiwibWFuYWdlLWFjY291bnQiLCJtYW5hZ2UtYWNjb3VudC1saW5rcyIsInZpZXctcHJvZmlsZSJdLCJwcmVmZXJyZWRfdXNlcm5hbWUiOiJ1c2VyLWFkbWluIiwiZ2l2ZW5fbmFtZSI6IiIsImZhbWlseV9uYW1lIjoiIn0.irG3H_RBle_CavKmek-77JL7c84-SoRiZ06zeGOIEFac7w2NLJ0pJUP-wnc8XJ-Aqxk4ymGEK2-gLEdKTCvRmSEVzHL48FbjuiCalXCJ1TYtZz3holRbSuiv31V0xFKzeV0lqD7AhBs_2ZhM_Alj6wtdjwpbjwGQroMymmDmcjMemEhZQc3kSX7elOKuTUOvqu_MTLV74qli1hxCjbwpqfIrfL7G5C91V7pnHO98PXSQN2VYveShG3W17S_Xmn5acM4sPFSdvD4gcA-61ZfR1py7NFhHwd5Etk27BOrmLSVfNxKIhGZd5vAkYZVPj6w-4_NkGAgry_gi1KSuStuPMw'
```

Now you should receive an HTTP 200 response:

![image](https://github.com/user-attachments/assets/45ece1f7-f32c-44f9-bfcd-a0b23a40349f)
