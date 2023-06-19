import requests
import json
import sys

# @pytest.mark.skip(reason="")
def test_post_headers_body_json():
    url = 'https://localhost:7010/pizza'

    # Additional headers.
    headers = {'Content-Type': 'application/json' } 

    # Body
    payload = {'name': "chocolate", 'isGlutenFree': False}
    
    # convert dict to json string by json.dumps() for body data. 
    resp = requests.post(url, headers=headers, data=json.dumps(payload,indent=4), verify=False)       
    
    # Validate response headers and body contents, e.g. status code.
    # CreatedAtAction 201: The pizza was added to the in-memory cache.
    assert resp.status_code == 201
    resp_body = resp.json()
    assert resp_body['name'] == "chocolate"
    
    # print response full body as text
    print(resp.text) #resp.text: {"id":11,"name":"chocolate","isGlutenFree":false}


"""
Reference: 
    https://peter-jp-xie.medium.com/rest-api-testing-using-python-751022c364b8
    https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-7.0&tabs=linux-ubuntu
    https://stackoverflow.com/questions/24617397/how-to-print-to-console-in-pytest 
Post request in Postman, Body - raw - Json (success)
! command: pytest test_add_pizza.py -s [to see print statements as they are executed]
"""