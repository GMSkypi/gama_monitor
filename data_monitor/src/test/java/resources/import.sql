
CREATE TABLE IF NOT EXISTS Container(id VARCHAR(128),docekr_id VARCHAR(128),names VARCHAR(128),image VARCHAR(128));

/* Table 'CPU' */
CREATE TABLE IF NOT EXISTS CPU(Container_id VARCHAR(128),u_space_pr long,k_space_pr long,u_space_ms long,k_space_ms long,throttle_ns long,throttle_cnt long,total_ns long,total_pr long,date_time timestamp);

/* Table 'Memory' */
CREATE TABLE IF NOT EXISTS Memory(mem_used long,mem_swap_used long,rss long,cacheC long,swap long,mem_limit long,mem_swap_limit long,mem_hit_cnt long,mem_swap_hit_cnt long,date_time timestamp,Container_id VARCHAR(128));

/* Table 'IO' */
CREATE TABLE IF NOT EXISTS IO(read long,write long,date_time timestamp,Container_id VARCHAR(128));


/* Table 'NET' */
CREATE TABLE IF NOT EXISTS NET(receive long,receive_error long,receive_error_total long,transmit long,transmit_error long,transmit_error_total long,date_time timestamp,Container_id VARCHAR(128));
