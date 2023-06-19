import requests
import json
import pytest

# @pytest.mark.skip(reason="")
def test_add_pizza():
    url = "https://localhost:7010/pizza"

    payload = json.dumps({
        "name": "Pepperoni",
        "isGlutenFree": False
    })
    headers = {
        'Content-Type': 'application/json'
    }

    response = requests.request("GET", url, headers=headers, data=payload,verify=False)

    print(response.text)