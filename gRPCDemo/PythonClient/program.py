#pip3 install grpcio grpcio-tools
#python3 -m grpc_tools.protoc -I. --python_out=. --grpc_python_out=. shopping.proto

import grpc
import google.protobuf
import shopping_pb2
import shopping_pb2_grpc

channel = grpc.insecure_channel('localhost:6001')
client = shopping_pb2_grpc.ShopKeeperStub(channel)
item = input('Item [all]: ')
if len(item) :
	info = client.GetItemInfo(shopping_pb2.ItemInfoRequest(name=item))
	if info.currentStock > 0:
		print('Unit Price =', info.unitPrice)
	else:
		print('Not available')
else:
	items = client.GetItemNames(google.protobuf.empty_pb2.Empty())
	print('Available items')
	for item in items:
		print(item.name)


	


