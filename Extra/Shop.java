import java.io.IOException;
import java.io.FileInputStream;
import java.io.DataInputStream;
import java.util.TreeMap;

record ItemInfo(double price, int stock) {}

class Shop {
	
	private TreeMap<String, ItemInfo> store;

	public Shop() throws IOException {
		var input = new DataInputStream(new FileInputStream("store.data"));
		store = new TreeMap<String, ItemInfo>();
		while(input.available() > 0){
			String name = input.readUTF();
			double price = input.readDouble();
			int stock = input.readInt();
			store.put(name, new ItemInfo(price, stock));
		}
	}

	public ItemInfo find(String name) {
		return store.get(name);
	}
}

