package shopping.app;

import shopping.*;
import io.grpc.Server;
import io.grpc.ServerBuilder;
import io.grpc.stub.StreamObserver;
import com.google.protobuf.Empty;
import java.util.Random;
import java.util.Arrays;

public class ShopServer {

	public static void main(String [] args) throws Exception{
    	Server server = ServerBuilder.forPort(6001)
        	.addService(new ShopKeeperService()).build();
    	server.start();
    	System.out.println("Server started, listening on port 6001.");
    	server.awaitTermination();
  	}

  	public static class ShopKeeperService extends ShopKeeperGrpc.ShopKeeperImplBase {

		private static String[] items = {"cpu", "hdd", "keyboard", "monitor", "motherboard", "mouse", "ram"};
		private static Random rdm = new Random();

    	@Override
    	public void getItemInfo(ItemInfoRequest request, StreamObserver<ItemInfoReply> responseObserver) {
			double[] prices = {24000, 5000, 1000, 9500, 15000, 500, 2000};
      		String itemName = request.getName();
			int i = Arrays.binarySearch(items, itemName);
			double price = 0;
			int stock = 0;
			if(i >= 0){
				price = prices[i];
				stock = 100 + 50 * rdm.nextInt(5);
			}
      		ItemInfoReply response = ItemInfoReply.newBuilder()
				.setUnitPrice(price)
				.setCurrentStock(stock)
				.build();
      		responseObserver.onNext(response);
      		responseObserver.onCompleted();
    	}
    
		@Override
		public void getItemNames(Empty request, StreamObserver<ItemInfoRequest> responseObserver) {
			for(String item : items)
				responseObserver.onNext(ItemInfoRequest.newBuilder().setName(item).build());
			responseObserver.onCompleted();
		}
  	}
}

