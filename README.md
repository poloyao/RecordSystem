# RecordSystem
使用Ef、sqlite.codeFirst构建sqlite 
# 注意
注意config配置数据库链接字符串，以便生成相应的数据库。
## ef
db.Set<NewsLog>().Add()插入操作的时候，如果传入某一个实体，则需要在此上下文中查询到相应的实体数据替换掉。
`
	var userItems = db.Set<User>().ToList();
	var user = userItems.SingleOrDefault(x => x.Id == ((User)this.comboBox.SelectedItem).Id);
	db.Set<NewsLog>().Add(new NewsLog { UserID = user, NewsID = new News() { NewsTitle = this.textBox.Text }, UDP = DateTime.Now });
	db.SaveChanges();
`
