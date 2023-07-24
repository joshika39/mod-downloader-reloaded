import os
import json

class JsonService():
    @classmethod
    def from_object(cls, obj):
        

    def __init__(self, json_input: dict, out_file: str) -> None:
        if not os.path.exists(out_file):
            print(f"The given json file does not exists! ({out_file})")
            exit(1)
        self._out_file = out_file
        json_data = open(self._out_file, 'r').read()
        self._data = json.loads(json_data)  # type:dict

    def read(self, key: str):
        if '/' in key:
            return self.read_subkey(key.split('/'), self._data)
        else:
            return self.read_subkey([key], self._data)

    def has_key(self, key: str) -> bool:
        if '/' in key:
            res = self.read_subkey(key.split('/'), self._data)
        else:
            res = self.read_subkey([key], self._data)

        return res is not None

    def read_subkey(self, keys: list[str], source: dict):
        if len(keys) == 0 or type(source) is not dict:
            return None

        if len(keys) == 1:

            if keys[0] in source.keys():
                return source[keys[0]]
            else:
                return None

        if keys[0] in source.keys():
            return self.read_subkey(keys[1:], source[keys[0]])

        return None            

    def write(self, path: str, value):
        keys = path.split('/')
        result = self._data

        temp = result
        for i, key in enumerate(keys[:-1]):
            if key not in temp:
                temp[key] = {}
            temp = temp[key]

        temp[keys[-1]] = value

        with open(self._out_file, "w") as outfile:
            json.dump(self._data, outfile)
