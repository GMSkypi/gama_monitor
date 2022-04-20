CREATE TABLE IF NOT EXISTS Container(id symbol,docekr_id string,names string,image string);
ALTER TABLE Container ALTER COLUMN id ADD INDEX;

/* Table 'CPU' */
CREATE TABLE IF NOT EXISTS CPU(Container_id symbol,u_space_pr long,k_space_pr long,u_space_ms long,k_space_ms long,throttle_ns long,throttle_cnt long,total_ns long,total_pr long,date_time timestamp)timestamp(date_time) PARTITION BY DAY;
ALTER TABLE CPU ALTER COLUMN Container_id ADD INDEX;
/* Table 'Memory' */
CREATE TABLE IF NOT EXISTS Memory(mem_used long,mem_swap_used long,rss long,cacheC long,swap long,mem_limit long,mem_swap_limit long,mem_hit_cnt long,mem_swap_hit_cnt long,date_time timestamp,Container_id symbol)timestamp(date_time) PARTITION BY DAY;
ALTER TABLE Memory ALTER COLUMN Container_id ADD INDEX;

/* Table 'IO' */
CREATE TABLE IF NOT EXISTS IO(read long,write long,date_time timestamp,Container_id symbol)timestamp(date_time) PARTITION BY DAY;
ALTER TABLE IO ALTER COLUMN Container_id ADD INDEX;

/* Table 'NET' */
CREATE TABLE IF NOT EXISTS NET(receive long,receive_error long,receive_error_total long,transmit long,transmit_error long,transmit_error_total long,date_time timestamp,Container_id symbol)timestamp(date_time) PARTITION BY DAY;
ALTER TABLE NET ALTER COLUMN Container_id ADD INDEX;
