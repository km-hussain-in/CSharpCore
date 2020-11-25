package shopping.app;

import shopping.*;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import com.google.protobuf.Empty;
import java.util.Iterator;

public class ShopClient {
  	public static void main(String[] args) throws InterruptedException {
    	ManagedChannel channel = ManagedChannelBuilder.forAddress("localhost", 6001)
        	.usePlaintext()
			.build();
    	ShopKeeperGrpc.ShopKeeperBlockingStub stub = ShopKeeperGrpc.newBlockingStub(channel);
		if(args.length > 0){
			ItemInfoRequest request = ItemInfoRequest.newBuilder().setName(args[0]).build();
    		ItemInfoReply response = stub.getItemInfo(request);
			if(response.getCurrentStock() > 0)
    			System.out.printf("Unit Price: %.2f%n", response.getUnitPrice());
			else
				System.out.println("Not available!");
		}else{
			Iterator<ItemInfoRequest> entries = stub.getItemNames(Empty.getDefaultInstance());
			System.out.println("Available items");
			while(entries.hasNext())
				System.out.println(entries.next().getName());

		}
    	channel.shutdown();
  	}
}

